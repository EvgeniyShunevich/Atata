﻿namespace Atata;

/// <summary>
/// Represents the log manager, an entry point for the Atata logging functionality.
/// </summary>
/// <seealso cref="ILogManager" />
internal sealed class LogManager : ILogManager
{
    private readonly LogManagerConfiguration _configuration;

    private readonly ILogEventInfoFactory _logEventInfoFactory;

    private readonly Lazy<ConcurrentDictionary<string, ILogManager>> _lazyExternalSourceLogManagerMap = new();

    private readonly Lazy<ConcurrentDictionary<string, ILogManager>> _lazyCategoryLogManagerMap = new();

    private readonly Stack<LogSection> _sectionEndStack = new();

    internal LogManager(
        LogManagerConfiguration configuration,
        ILogEventInfoFactory logEventInfoFactory)
    {
        _configuration = configuration;
        _logEventInfoFactory = logEventInfoFactory;
    }

    /// <inheritdoc/>
    public void Trace(string message) =>
        Log(LogLevel.Trace, message);

    /// <inheritdoc/>
    public void Debug(string message) =>
        Log(LogLevel.Debug, message);

    /// <inheritdoc/>
    public void Info(string message) =>
        Log(LogLevel.Info, message);

    /// <inheritdoc/>
    public void Warn(string message) =>
        Log(LogLevel.Warn, message);

    /// <inheritdoc/>
    public void Warn(Exception exception) =>
        Log(LogLevel.Warn, null, exception);

    /// <inheritdoc/>
    public void Warn(Exception exception, string message) =>
        Log(LogLevel.Warn, message, exception);

    /// <inheritdoc/>
    public void Error(Exception exception) =>
        Log(LogLevel.Error, null, exception);

    /// <inheritdoc/>
    public void Error(string message) =>
        Log(LogLevel.Error, message);

    /// <inheritdoc/>
    public void Error(Exception exception, string message) =>
        Log(LogLevel.Error, message, exception);

    /// <inheritdoc/>
    public void Fatal(Exception exception) =>
        Log(LogLevel.Fatal, null, exception);

    /// <inheritdoc/>
    public void Fatal(string message) =>
        Log(LogLevel.Fatal, message);

    /// <inheritdoc/>
    public void Fatal(Exception exception, string message) =>
        Log(LogLevel.Fatal, message, exception);

    /// <inheritdoc/>
    public void ExecuteSection(LogSection section, Action action)
    {
        section.CheckNotNull(nameof(section));
        action.CheckNotNull(nameof(action));

        StartSection(section);

        try
        {
            action.Invoke();
        }
        catch (Exception exception)
        {
            section.Exception = exception;
            throw;
        }
        finally
        {
            EndCurrentSection();
        }
    }

    /// <inheritdoc/>
    public TResult ExecuteSection<TResult>(LogSection section, Func<TResult> function)
    {
        section.CheckNotNull(nameof(section));
        function.CheckNotNull(nameof(function));

        StartSection(section);

        try
        {
            TResult result = function.Invoke();
            section.Result = result;
            return result;
        }
        catch (Exception exception)
        {
            section.Exception = exception;
            throw;
        }
        finally
        {
            EndCurrentSection();
        }
    }

    /// <inheritdoc/>
    public async Task ExecuteSectionAsync(LogSection section, Func<Task> function)
    {
        section.CheckNotNull(nameof(section));
        function.CheckNotNull(nameof(function));

        StartSection(section);

        try
        {
            await function.Invoke();
        }
        catch (Exception exception)
        {
            section.Exception = exception;
            throw;
        }
        finally
        {
            EndCurrentSection();
        }
    }

    /// <inheritdoc/>
    public async Task<TResult> ExecuteSectionAsync<TResult>(LogSection section, Func<Task<TResult>> function)
    {
        section.CheckNotNull(nameof(section));
        function.CheckNotNull(nameof(function));

        StartSection(section);

        try
        {
            TResult result = await function.Invoke();
            section.Result = result;
            return result;
        }
        catch (Exception exception)
        {
            section.Exception = exception;
            throw;
        }
        finally
        {
            EndCurrentSection();
        }
    }

    /// <inheritdoc/>
    public ILogManager ForExternalSource(string externalSource)
    {
        externalSource.CheckNotNullOrWhitespace(nameof(externalSource));

        return _lazyExternalSourceLogManagerMap.Value.GetOrAdd(
            externalSource,
            x => new LogManager(
                _configuration,
                new ExternalSourceLogEventInfoFactory(_logEventInfoFactory, x)));
    }

    /// <inheritdoc/>
    public ILogManager ForCategory(string category)
    {
        category.CheckNotNullOrWhitespace(nameof(category));

        return _lazyCategoryLogManagerMap.Value.GetOrAdd(
            category,
            x => new LogManager(
                _configuration,
                new CategoryLogEventInfoFactory(_logEventInfoFactory, x)));
    }

    /// <inheritdoc/>
    public ILogManager ForCategory<TCategory>() =>
        ForCategory(typeof(TCategory).FullName);

    private static string AppendSectionResultToMessage(string message, object result)
    {
        string resultAsString = result is Exception resultAsException
            ? BuildExceptionShortSingleLineMessage(resultAsException)
            : Stringifier.ToString(result);

        string separator = resultAsString.Contains(Environment.NewLine)
            ? Environment.NewLine
            : " ";

        return $"{message} >>{separator}{resultAsString}";
    }

    private static string BuildExceptionShortSingleLineMessage(Exception exception)
    {
        string message = exception.Message;

        int newLineIndex = message.IndexOf(Environment.NewLine, StringComparison.Ordinal);

        if (newLineIndex >= 0)
        {
            message = message.Substring(0, newLineIndex);

            message += message[message.Length - 1] == '.'
                ? ".."
                : "...";
        }

        return $"{exception.GetType().FullName}: {message}";
    }

    private static string PrependHierarchyPrefixesToMessage(string message, LogEventInfo eventInfo, LogConsumerConfiguration logConsumerConfiguration)
    {
        StringBuilder builder = new StringBuilder();

        if (eventInfo.NestingLevel > 0)
        {
            for (int i = 0; i < eventInfo.NestingLevel; i++)
            {
                builder.Append(logConsumerConfiguration.MessageNestingLevelIndent);
            }
        }

        if (logConsumerConfiguration.SectionEnd != LogSectionEndOption.Exclude)
        {
            var logSection = eventInfo.SectionStart ?? eventInfo.SectionEnd;

            if (logSection is not null &&
                (logConsumerConfiguration.SectionEnd == LogSectionEndOption.Include || IsBlockLogSection(logSection)))
            {
                builder.Append(
                    eventInfo.SectionStart != null
                        ? logConsumerConfiguration.MessageStartSectionPrefix
                        : logConsumerConfiguration.MessageEndSectionPrefix);
            }
        }

        string resultMessage = builder.Append(message).ToString();

        return resultMessage.Length == 0 && message == null
            ? null
            : resultMessage;
    }

    private static IEnumerable<LogConsumerConfiguration> FilterByLogSectionEnd(
        IEnumerable<LogConsumerConfiguration> configurations,
        LogSection logSection)
    {
        foreach (var configuration in configurations)
        {
            if (configuration.SectionEnd == LogSectionEndOption.Include ||
                (configuration.SectionEnd == LogSectionEndOption.IncludeForBlocks && IsBlockLogSection(logSection)))
                yield return configuration;
        }
    }

    private static bool IsBlockLogSection(LogSection logSection) =>
        logSection is AggregateAssertionLogSection or SetupLogSection or StepLogSection;

    private void StartSection(LogSection section)
    {
        LogEventInfo eventInfo = _logEventInfoFactory.Create(section.Level, section.Message);
        eventInfo.SectionStart = section;

        section.StartedAt = eventInfo.Timestamp;
        section.Stopwatch.Start();

        Log(eventInfo);

        _sectionEndStack.Push(section);
    }

    private void EndCurrentSection()
    {
        if (_sectionEndStack.Any())
        {
            LogSection section = _sectionEndStack.Pop();

            section.Stopwatch.Stop();

            string message = $"{section.Message} ({section.ElapsedTime.ToLongIntervalString()})";

            if (section.IsResultSet)
                message = AppendSectionResultToMessage(message, section.Result);
            else if (section.Exception != null)
                message = AppendSectionResultToMessage(message, section.Exception);

            LogEventInfo eventInfo = _logEventInfoFactory.Create(section.Level, message);
            eventInfo.SectionEnd = section;

            Log(eventInfo);
        }
    }

    private void Log(LogLevel level, string message, Exception exception = null)
    {
        LogEventInfo logEvent = _logEventInfoFactory.Create(level, message);
        logEvent.Exception = exception;

        Log(logEvent);
    }

    private void Log(LogEventInfo eventInfo)
    {
        var appropriateConsumerItems = _configuration.ConsumerConfigurations
            .Where(x => eventInfo.Level >= x.MinLevel);

        if (eventInfo.SectionEnd != null)
            appropriateConsumerItems = FilterByLogSectionEnd(appropriateConsumerItems, eventInfo.SectionEnd);

        string originalMessage = ApplySecretMasks(eventInfo.Message);

        foreach (var consumerItem in appropriateConsumerItems)
        {
            eventInfo.NestingLevel = _sectionEndStack.Count(x => x.Level >= consumerItem.MinLevel);
            eventInfo.Message = PrependHierarchyPrefixesToMessage(originalMessage, eventInfo, consumerItem);

            consumerItem.Consumer.Log(eventInfo);
        }
    }

    private string ApplySecretMasks(string message)
    {
        foreach (var secret in _configuration.SecretStringsToMask)
            message = message.Replace(secret.Value, secret.Mask);

        return message;
    }
}
