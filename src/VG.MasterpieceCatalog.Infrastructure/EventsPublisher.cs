using System.Collections.Concurrent;
using System.Collections.Generic;
using Rebus.Bus;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class EventsPublisher : IEventsPublisher
  {
    private readonly IEventsConverter _converter;
    private readonly ConcurrentQueue<Event> _queue;

    public EventsPublisher(IEventsConverter converter, ConcurrentQueue<Event> queue)
    {
      _converter = converter;
      _queue = queue;
    }

    public void Publish(IEnumerable<IEvent> events)
    {
      foreach (var @event in events)
      {
        _queue.Enqueue(_converter.Convert(@event));
      }
    }
  }
}