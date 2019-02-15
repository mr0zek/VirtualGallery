using System;
using System.Reflection;
using Autofac;
using RestEase;
using VG.Notification.ExternalInterfaces;
using VG.Notification.Features.MasterpieceReservationNotification;

namespace VG.Notification.Infrastructure
{
  public class EventSubscriber : IEventSubscriber
  {
    private string _masterpieceCatalogUrl;
    private IContainer _container;
    private readonly IProcessedEventsRepository _processedEventsRepository;

    public EventSubscriber(string masterpieceCatalogUrl, IContainer container, IProcessedEventsRepository processedEventsRepository)
    {
      _masterpieceCatalogUrl = masterpieceCatalogUrl;
      _container = container;
      _processedEventsRepository = processedEventsRepository;
    }

    public int ProcessEvents(int eventsCount)
    {
      IMasterpieceEventsApi api = RestClient.For<IMasterpieceEventsApi>($"{_masterpieceCatalogUrl}/api/events");

      int lastProcessedEventId = _processedEventsRepository.GetLastProcessedEventId();
      var events = api.GetEvents(lastProcessedEventId, eventsCount);

      foreach (var @event in events)
      {
        Type eventListenerType = typeof(IEventListener<>).MakeGenericType(@event.GetType());
        var eventListener = _container.Resolve(eventListenerType);
        eventListenerType.InvokeMember("Handle", BindingFlags.Default, null, eventListener, new object[]{ @event });
        _processedEventsRepository.SetLastProcessedEventId(@event.Id);
      }

      return events.Length;
    }
  }
}