using System;
using System.Threading.Tasks;
using System.Timers;
using Autofac;
using Hangfire;
using log4net;
using VG.MasterpieceCatalog.Perspective.Infrastructure;

namespace VG.MasterpieceCatalog.Perspective
{
  public class PerspectiveBootstrap
  {
    private static readonly Timer _timer = new Timer();
    private static bool _processing;
    private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public static void Run(string[] args, Action<ContainerBuilder> builderFunc, string connectionString, string eventsUrl)
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.RegisterModule(new PerspectiveAutofacModule(connectionString, eventsUrl));
      builderFunc(builder);
      var container = builder.Build();

      GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

      _timer.Interval = 1000;
      _timer.Elapsed += (sender, eventArgs) => RunEventsCheck(container.Resolve<IEventSubscriber>());
      _timer.Enabled = true;
      _timer.Start();
    }

    public static void RunEventsCheck(IEventSubscriber eventSubscriber)
    {
      lock (_timer)
      {
        if (_processing)
        {
          return;
        }

        _processing = true;
      }

      try
      {
        var eventsCount = 100;

        while (true)
        {
          Task<int> count = eventSubscriber.ProcessEvents(eventsCount);
          count.Wait();
          if (count.Result < eventsCount)
          {
            break;
          }
        }
      }
      catch (Exception ex)
      {
        _log.Error("Error during message processing", ex);
      }
      finally
      {
        _processing = false;
      }
    }
  }
}
