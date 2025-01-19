﻿#nullable enable

namespace Atata;

/// <summary>
/// Provides the navigation functionality between pages and windows.
/// </summary>
public static class Go
{
    /// <inheritdoc cref="AtataNavigator.On{T}"/>
    public static T On<T>()
       where T : PageObject<T> =>
        ResolveWebSession().Go.On<T>();

    /// <inheritdoc cref="AtataNavigator.OnRefreshed{T}"/>
    public static T OnRefreshed<T>()
       where T : PageObject<T> =>
        ResolveWebSession().Go.OnRefreshed<T>();

    /// <inheritdoc cref="AtataNavigator.OnOrTo{T}"/>
    public static T OnOrTo<T>()
       where T : PageObject<T> =>
        ResolveWebSession().Go.OnOrTo<T>();

    /// <inheritdoc cref="AtataNavigator.To{T}(T, string, bool, bool)"/>
    public static T To<T>(T? pageObject = null, string? url = null, bool navigate = true, bool temporarily = false)
        where T : PageObject<T> =>
        ResolveWebSession().Go.To(pageObject, url, navigate, temporarily);

    /// <inheritdoc cref="AtataNavigator.ToWindow{T}(T, string, bool)"/>
    public static T ToWindow<T>(T pageObject, string windowName, bool temporarily = false)
        where T : PageObject<T> =>
        ResolveWebSession().Go.ToWindow(pageObject, windowName, temporarily);

    /// <inheritdoc cref="AtataNavigator.ToWindow{T}(string, bool)"/>
    public static T ToWindow<T>(string windowName, bool temporarily = false)
        where T : PageObject<T> =>
        ResolveWebSession().Go.ToWindow<T>(windowName, temporarily);

    /// <inheritdoc cref="AtataNavigator.ToNextWindow{T}(T, bool)"/>
    public static T ToNextWindow<T>(T? pageObject = null, bool temporarily = false)
        where T : PageObject<T> =>
        ResolveWebSession().Go.ToNextWindow(pageObject, temporarily);

    /// <inheritdoc cref="AtataNavigator.ToPreviousWindow{T}(T, bool)"/>
    public static T ToPreviousWindow<T>(T? pageObject = null, bool temporarily = false)
        where T : PageObject<T> =>
        ResolveWebSession().Go.ToPreviousWindow(pageObject, temporarily);

    /// <inheritdoc cref="AtataNavigator.ToNewWindowAsTab{T}(T, string, bool)"/>
    public static T ToNewWindowAsTab<T>(T? pageObject = null, string? url = null, bool temporarily = false)
        where T : PageObject<T> =>
        ResolveWebSession().Go.ToNewWindowAsTab(pageObject, url, temporarily);

    /// <inheritdoc cref="AtataNavigator.ToNewWindow{T}(T, string, bool)"/>
    public static T ToNewWindow<T>(T? pageObject = null, string? url = null, bool temporarily = false)
        where T : PageObject<T> =>
        ResolveWebSession().Go.ToNewWindow(pageObject, url, temporarily);

    /// <inheritdoc cref="AtataNavigator.ToUrl(string)"/>
    public static void ToUrl(string url) =>
        ResolveWebSession().Go.ToUrl(url);

    private static WebSession ResolveWebSession() =>
        WebSession.Current;
}
