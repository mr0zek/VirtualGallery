using System;
using System.Collections.Concurrent;
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
    private readonly ConcurrentQueue<Event> _queue;
    private readonly IContainer _container;
    
    public EventSubscriber(ConcurrentQueue<Event> queue, IContainer container)
    {
      _queue = queue;
      _container = container;
    }

    public async Task<int> ProcessEvents(int eventsCount)
    {
      int count = 0;
      while(_queue.TryDequeue(out var item))
      {
        count++;
        Type eventListenerType = typeof(IEventListener<>).MakeGenericType(item.GetType());
        if (_container.HasRegistration(eventListenerType))
        {
          var eventListener = _container.Resolve(eventListenerType);
          eventListenerType.InvokeMember("Handle", BindingFlags.InvokeMethod, null, eventListener,
            new object[] {item});
        }
        else
        {
          _log.Warn("Cannot find listener for message type :"+ item.GetType());
        }      
      }

      return count;
    }
  }
}