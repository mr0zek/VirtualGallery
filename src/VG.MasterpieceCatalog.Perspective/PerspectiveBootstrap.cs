using System;
using Autofac;
using Hangfire;
using VG.MasterpieceCatalog.Perspective.Infrastructure;

namespace VG.MasterpieceCatalog.Perspective
{
  public class PerspectiveBootstrap
  {
    public static void Run(string[] args, Action<ContainerBuilder> builderFunc, string connectionString, string masterpieceCatalogUrl)
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.RegisterModule(new PerspectiveAutofacModule(connectionString, masterpieceCatalogUrl));
      builderFunc(builder);
      var container = builder.Build();

      GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

      BackgroundJob.Schedule(() => RunEventsCheck(container.Resolve<IEventSubscriber>()), TimeSpan.FromMilliseconds(2000));
    }

    public static void RunEventsCheck(IEventSubscriber eventSubscriber)
    {
      var eventsCount = 100;

      while(eventSubscriber.ProcessEvents(eventsCount) == eventsCount)
      { }

      BackgroundJob.Schedule(() => RunEventsCheck(eventSubscriber), TimeSpan.FromMilliseconds(2000));
    }    
  }
}
