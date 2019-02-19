using System;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  namespace VG.MasterpieceCatalog.Domain.BaseTypes
  {
    /// <summary>
    /// AggregateRoot for EventStore
    /// </summary>
    public class AggregateRoot : IEventsAccesor
    {
      private readonly List<IEvent> _changes = new List<IEvent>();

      public string Id { get; protected set; }
      public int Version { get; internal set; }

      IEnumerable<IEvent> IEventsAccesor.GetEvents()
      {
        return _changes;
      }

      protected void PublishEvent(IEvent @event)
      {
        _changes.Add(@event);
      }
    }
  }
}