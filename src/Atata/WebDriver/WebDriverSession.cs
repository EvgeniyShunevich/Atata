﻿namespace Atata;

/// <summary>
/// <para>
/// Represents a session that manages <see cref="IWebDriver"/> instance
/// and provides a set of functionality to manipulate the driver.
/// </para>
/// <para>
/// The class adds additional variable to its <see cref="AtataSession.Variables"/>: <c>{driver-alias}</c>.
/// </para>
/// </summary>
public class WebDriverSession : WebSession
{
    private IWebDriverFactory _driverFactory;

    private IWebDriver _driver;

    public WebDriverSession() =>
        Go = new AtataNavigator(this);

    public static new WebDriverSession Current =>
        AtataContext.ResolveCurrent().Sessions.Get<WebDriverSession>();

    /// <inheritdoc cref="WebSession.Report"/>
    public new IWebSessionReport<WebDriverSession> Report =>
        (IWebSessionReport<WebDriverSession>)base.Report;

    internal IWebDriverFactory DriverFactory
    {
        get => _driverFactory;
        set
        {
            _driverFactory = value;

            // TODO: Review the "driver-alias" variable set along with DriverFactory set.
            Variables.SetInitialValue("driver-alias", DriverAlias);
        }
    }

    /// <summary>
    /// Gets the driver.
    /// </summary>
    public IWebDriver Driver =>
        _driver;

    /// <summary>
    /// Gets a value indicating whether this instance has <see cref="Driver"/> instance.
    /// </summary>
    // TODO: Remove HasDriver property.
    public bool HasDriver =>
        _driver != null;

    /// <summary>
    /// Gets the driver alias.
    /// </summary>
    public string DriverAlias =>
        DriverFactory?.Alias;

    internal bool DisposeDriver { get; set; }

    /// <summary>
    /// Gets the default control visibility.
    /// The default value is <see cref="Visibility.Any"/>.
    /// </summary>
    public Visibility DefaultControlVisibility { get; internal set; }

    /// <summary>
    /// Gets the UI component access chain scope cache.
    /// </summary>
    public UIComponentAccessChainScopeCache UIComponentAccessChainScopeCache { get; } = new();

    /// <summary>
    /// Creates <see cref="WebDriverSessionBuilder"/> instance for <see cref="WebDriverSession"/> configuration.
    /// </summary>
    /// <returns>The created <see cref="WebDriverSessionBuilder"/> instance.</returns>
    public static WebDriverSessionBuilder CreateBuilder() => new();

    protected internal override async Task StartAsync(CancellationToken cancellationToken = default) =>
        await Task.Run(InitDriver, cancellationToken)
            .ConfigureAwait(false);

    private void InitDriver() =>
        Log.ExecuteSection(
            new LogSection("Initialize Driver", LogLevel.Trace),
            () =>
            {
                if (DriverFactory is null)
                    throw new WebDriverInitializationException(
                        $"Failed to create a driver as driver factory is not specified.");

                _driver = DriverFactory.Create(Log)
                    ?? throw new WebDriverInitializationException(
                        $"Driver factory returned null as a driver.");

                // TODO: v4. Move these RetrySettings out of here.
                RetrySettings.Timeout = ElementFindTimeout;
                RetrySettings.Interval = ElementFindRetryInterval;

                EventBus.Publish(new DriverInitEvent(_driver));
            });

#warning Probably replace RestartDriver method with restart session functionality.
    /// <summary>
    /// Restarts the driver.
    /// </summary>
    public void RestartDriver() =>
        Log.ExecuteSection(
            new LogSection("Restart driver"),
            () =>
            {
                CleanUpTemporarilyPreservedPageObjectList();

                if (PageObject != null)
                {
                    UIComponentResolver.CleanUpPageObject(PageObject);
                    PageObject = null;
                }

                EventBus.Publish(new DriverDeInitEvent(_driver));
                DisposeDriverSafely();

                InitDriver();
            });

    protected override async ValueTask DisposeAsyncCore()
    {
        CleanUpTemporarilyPreservedPageObjectList();

        if (PageObject != null)
            UIComponentResolver.CleanUpPageObject(PageObject);

        UIComponentAccessChainScopeCache.Release();

        if (_driver is not null)
        {
            EventBus.Publish(new DriverDeInitEvent(_driver));

            if (DisposeDriver)
                DisposeDriverSafely();
        }

        await base.DisposeAsyncCore().ConfigureAwait(false);
    }

    private void DisposeDriverSafely()
    {
        try
        {
            _driver.Dispose();
        }
        catch (Exception exception)
        {
            Log.Warn(exception, "Deinitialization of driver failed.");
        }
    }
}
