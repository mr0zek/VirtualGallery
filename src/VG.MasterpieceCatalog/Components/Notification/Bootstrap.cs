using System;
using Autofac;
using Hangfire;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace VG.MasterpieceCatalog.Components.Notification
{
  public class NotificationBootstrap
  {
    public static void Run(string[] args, Action<ContainerBuilder> builderFunc)
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.RegisterAssemblyModules<NotificationAutofacModule>();
      builderFunc(builder);

      BackgroundJob.Schedule(() => RunEventsCheck(), TimeSpan.FromMilliseconds(2000));
    }

    public static void RunEventsCheck()
    {


      BackgroundJob.Schedule(() => RunEventsCheck(), TimeSpan.FromMilliseconds(2000));
    }    
  }  
}
