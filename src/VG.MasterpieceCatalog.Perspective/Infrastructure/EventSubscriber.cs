using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using RestEase;
using VG.MasterpieceCatalog.Contract;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
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
      Task<Event[]> events = api.GetEvents(lastProcessedEventId, eventsCount);
      events.Wait();

      foreach (var @event in events.Result)
      {
        Type eventListenerType = typeof(IEventListener<>).MakeGenericType(@event.GetType());
        var eventListener = _container.Resolve(eventListenerType);
        eventListenerType.InvokeMember("Handle", BindingFlags.Default, null, eventListener, new object[]{ @event });
        _processedEventsRepository.SetLastProcessedEventId(@event.Id);
      }

      return events.Result.Length;
    }
  }
}