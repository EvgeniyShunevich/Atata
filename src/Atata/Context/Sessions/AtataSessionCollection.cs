﻿namespace Atata;

public sealed class AtataSessionCollection : IReadOnlyCollection<AtataSession>, IDisposable
{
    private readonly AtataContext _context;

    private readonly List<IAtataSessionBuilder> _sessionBuilders = [];

    private readonly List<AtataSession> _sessionListOrderedByAdding = [];

    private readonly LinkedList<AtataSession> _sessionLinkedListOderedByCurrentUsage = [];

    private readonly ReaderWriterLockSlim _sessionLinkedListOderedByCurrentUsageLock = new();

    internal AtataSessionCollection(AtataContext context) =>
        _context = context;

    public int Count =>
        _sessionListOrderedByAdding.Count;

    public TSession Get<TSession>()
        where TSession : AtataSession
    {
        _sessionLinkedListOderedByCurrentUsageLock.EnterReadLock();

        try
        {
            return _sessionLinkedListOderedByCurrentUsage.OfType<TSession>().FirstOrDefault()
                ?? throw AtataSessionNotFoundException.For<TSession>();
        }
        finally
        {
            _sessionLinkedListOderedByCurrentUsageLock.ExitReadLock();
        }
    }

    /// <summary>
    /// Gets a session of <typeparamref name="TSession"/> type with the specified index
    /// among sessions of the <typeparamref name="TSession"/> type.
    /// </summary>
    /// <typeparam name="TSession">The type of the session.</typeparam>
    /// <param name="index">The index.</param>
    /// <returns>A session.</returns>
    public TSession Get<TSession>(int index)
       where TSession : AtataSession
    {
        index.CheckIndexNonNegative();

        return _sessionListOrderedByAdding.OfType<TSession>().ElementAtOrDefault(index)
            ?? throw AtataSessionNotFoundException.ByIndex<TSession>(
                index,
                _sessionListOrderedByAdding.OfType<TSession>().Count());
    }

    /// <summary>
    /// Gets a first session of <typeparamref name="TSession"/> type with the specified name
    /// among sessions of the <typeparamref name="TSession"/> type.
    /// </summary>
    /// <typeparam name="TSession">The type of the session.</typeparam>
    /// <param name="name">The name.</param>
    /// <returns>A session.</returns>
    public TSession Get<TSession>(string name)
        where TSession : AtataSession
        =>
        _sessionListOrderedByAdding.OfType<TSession>().FirstOrDefault(x => x.Name == name)
            ?? throw AtataSessionNotFoundException.ByName<TSession>(
                name,
                _sessionListOrderedByAdding.OfType<TSession>().Count());

#warning Finish later Start methods.
    ////public TSession Start<TSessionBuilder, TSession>(string name = null)
    ////{
    ////    //return
    ////}

    ////public TSession Start<TSessionBuilder, TSession>(Action<TSessionBuilder> sessionConfiguration)
    ////    where TSessionBuilder : IAtataSessionBuilder
    ////{
    ////    var sessionBuilder = ActivatorEx.CreateInstance<TSessionBuilder>();

    ////    sessionConfiguration?.Invoke(sessionBuilder);

    ////    return (TSession)sessionBuilder.Build();
    ////}

    internal void AddBuilders(IEnumerable<IAtataSessionBuilder> sessionBuilders) =>
        _sessionBuilders.AddRange(sessionBuilders);

    public TSessionBuilder Add<TSessionBuilder>()
        where TSessionBuilder : IAtataSessionBuilder, new()
    {
        TSessionBuilder sessionBuilder = new()
        {
            TargetContext = _context
        };

        _sessionBuilders.Add(sessionBuilder);

        return sessionBuilder;
    }

    internal void Add(AtataSession session)
    {
        _sessionLinkedListOderedByCurrentUsageLock.EnterWriteLock();

        try
        {
            _sessionListOrderedByAdding.Add(session);
            _sessionLinkedListOderedByCurrentUsage.AddLast(session);
        }
        finally
        {
            _sessionLinkedListOderedByCurrentUsageLock.ExitWriteLock();
        }
    }

    internal void Remove(AtataSession session)
    {
        _sessionLinkedListOderedByCurrentUsageLock.EnterWriteLock();

        try
        {
            _sessionListOrderedByAdding.Remove(session);
            _sessionLinkedListOderedByCurrentUsage.Remove(session);
        }
        finally
        {
            _sessionLinkedListOderedByCurrentUsageLock.ExitWriteLock();
        }
    }

    internal void SetCurrent(AtataSession session)
    {
        _sessionLinkedListOderedByCurrentUsageLock.EnterWriteLock();

        try
        {
            if (_sessionLinkedListOderedByCurrentUsage.First.Value != session)
            {
                var node = _sessionLinkedListOderedByCurrentUsage.Find(session);
                _sessionLinkedListOderedByCurrentUsage.Remove(node);
                _sessionLinkedListOderedByCurrentUsage.AddFirst(node);
            }
        }
        finally
        {
            _sessionLinkedListOderedByCurrentUsageLock.ExitWriteLock();
        }
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();

    public IEnumerator<AtataSession> GetEnumerator() =>
        _sessionListOrderedByAdding.GetEnumerator();

    public void Dispose()
    {
        _sessionLinkedListOderedByCurrentUsageLock.Dispose();

        _sessionListOrderedByAdding.Clear();
        _sessionLinkedListOderedByCurrentUsage.Clear();
    }
}
