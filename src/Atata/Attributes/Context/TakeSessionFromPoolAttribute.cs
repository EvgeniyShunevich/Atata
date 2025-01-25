﻿#nullable enable

namespace Atata;

/// <summary>
/// Represents an attribute that configures <see cref="AtataContextBuilder"/>
/// to take the specified session from pool.
/// </summary>
public class TakeSessionFromPoolAttribute : AtataContextConfigurationAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TakeSessionFromPoolAttribute"/> class.
    /// </summary>
    /// <param name="sessionType">Type of the session.</param>
    /// <param name="sessionName">Name of the session. Can be <see langword="null"/>.</param>
    public TakeSessionFromPoolAttribute(Type sessionType, string? sessionName = null)
    {
        SessionType = sessionType.CheckNotNull(nameof(sessionType));
        SessionName = sessionName;
    }

    /// <summary>
    /// Gets the type of the session.
    /// </summary>
    public Type SessionType { get; }

    /// <summary>
    /// Gets the name of the session.
    /// </summary>
    public string? SessionName { get; }

    public override void ConfigureAtataContext(AtataContextBuilder builder)
    {
        builder.Sessions.ConfigureIfExists(
            SessionType,
            SessionName,
            x => x.StartScopes = AtataSessionStartScopes.None);
        builder.Sessions.TakeFromPool(SessionType, x => x.Name = SessionName);
    }
}
