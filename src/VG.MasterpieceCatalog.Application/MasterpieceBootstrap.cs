using System;
using System.Threading;
using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace VG.MasterpieceCatalog.Application
{
  public class MasterpieceBootstrap
  {
    public static void Run(string[] args, Action<ContainerBuilder> builder, int port)
    {
      MasterpieceStartup.RegisterExternalTypes = builder;
      ThreadPool.QueueUserWorkItem(starte => CreateWebHostBuilder(args, port).Build().Run());
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args, int port) =>
      WebHost.CreateDefaultBuilder(args)
        .UseKestrel(f => f.ListenAnyIP(port))        
        .UseStartup<MasterpieceStartup>();
  }  
}
