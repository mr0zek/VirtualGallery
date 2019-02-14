using System;
using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace VG.MasterpieceCatalog.Application
{
  public class MasterpieceBootstrap
  {
    public static void Run(string[] args, Action<ContainerBuilder> builder)
    {
      MasterpieceStartup.RegisterExternalTypes = builder;
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseKestrel(f => f.ListenAnyIP(12121))        
        .UseStartup<MasterpieceStartup>();
  }  
}
