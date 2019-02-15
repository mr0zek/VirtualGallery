using System;
using System.Collections.Generic;
using System.Linq;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  /// <summary>
  /// AggregateRoot for EventStore
  /// </summary>
  public class AggregateRootES : IEventsCollectionAccesor
  {
    private readonly List<IEvent> _changes = new List<IEvent>();

    public string Id { get; protected set; }
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

      Version = history.Count();
    }

    protected void PublishEvent(IEvent @event)
    {
      _changes.Add(@event);
    }
  }
}