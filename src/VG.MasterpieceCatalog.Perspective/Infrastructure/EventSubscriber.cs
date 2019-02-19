using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using log4net;
using Newtonsoft.Json;
using RestEase;
using VG.MasterpieceCatalog.Contract;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public class EventSubscriber : IEventSubscriber
  {
    private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private readonly string _masterpieceCatalogUrl;
    private readonly IContainer _container;
    private readonly IProcessedEventsRepository _processedEventsRepository;

    public EventSubscriber(string masterpieceCatalogUrl, IContainer container, IProcessedEventsRepository processedEventsRepository)
    {
      _masterpieceCatalogUrl = masterpieceCatalogUrl;
      _container = container;
      _processedEventsRepository = processedEventsRepository;
    }

    public async Task<int> ProcessEvents(int eventsCount)
    {
      IMasterpieceEventsApi api = new RestClient(_masterpieceCatalogUrl)
      {
        JsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects}
      }.For<IMasterpieceEventsApi>();

      int lastProcessedEventId = await _processedEventsRepository.GetLastProcessedEventIdAsync();
      Event[] events = await api.GetEventsAsync(lastProcessedEventId, eventsCount);

      foreach (var @event in events)
      {
        Type eventListenerType = typeof(IEventListener<>).MakeGenericType(@event.GetType());
        if (_container.HasRegistration(eventListenerType))
        {
          var eventListener = _container.Resolve(eventListenerType);
          eventListenerType.InvokeMember("Handle", BindingFlags.InvokeMethod, null, eventListener,
            new object[] { @event });
        }
        else
        {
          _log.Warn("Cannot find listener for message type :" + @event.GetType());
        }

        await _processedEventsRepository.SetLastProcessedEventIdAsync(@event.Id);
      }

      return events.Length;
    }
  }
}