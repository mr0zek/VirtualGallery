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

    private readonly string _eventsUrl;
    private readonly IContainer _container;
    private readonly IProcessedEventsRepository _processedEventsRepository;
    
    public EventSubscriber(string eventsUrl, IContainer container, IProcessedEventsRepository processedEventsRepository)
    {
      _eventsUrl = eventsUrl;
      _container = container;
      _processedEventsRepository = processedEventsRepository;
    }

    public async Task<int> ProcessEvents(int eventsCount)
    {
      IMasterpieceEventsApi api = new RestClient(_eventsUrl)
      {
        JsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects }
      }.For<IMasterpieceEventsApi>();

      int lastProcessedEventId = await _processedEventsRepository.GetLastProcessedEventIdAsync();
      MasterpieceEvents events = await api.GetEventsAsync(lastProcessedEventId, eventsCount);
      
      foreach (var @event in events.Events)
      {
        Type eventListenerType = typeof(IEventListener<>).MakeGenericType(@event.GetType());
        if (_container.HasRegistration(eventListenerType))
        {
          var eventListener = _container.Resolve(eventListenerType);
          eventListenerType.InvokeMember("Handle", BindingFlags.InvokeMethod, null, eventListener,
            new object[] {@event});
        }
        else
        {
          _log.Warn("Cannot find listener for message type :"+ @event.GetType());
        }

        _processedEventsRepository.SetLastProcessedEventIdAsync(@event.Id);        
      }

      return events.Events.Length;
    }
  }
}