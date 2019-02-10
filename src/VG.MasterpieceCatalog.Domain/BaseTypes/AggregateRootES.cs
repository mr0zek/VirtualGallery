using System;
using System.Collections.Generic;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  /// <summary>
  /// AggregateRoot for EventStore
  /// </summary>
  public class AggregateRootES : IEventsCollectionAccesor
  {
    private readonly List<IEvent> _changes = new List<IEvent>();

    public Guid Id { get; }
    public int Version { get; internal set; }

    IEnumerable<IEvent> IEventsCollectionAccesor.GetUncommittedChanges()
    {
      return _changes;
    }

    protected void LoadsFromHistory(IEnumerable<IEvent> history)
    {
      foreach (var e in history)
      {
        this.AsDynamic().Apply(e);
      }
    }

    protected void PublishEvent(IEvent @event)
    {
      this.AsDynamic().Apply(@event);
      _changes.Add(@event);
    }
  }
}