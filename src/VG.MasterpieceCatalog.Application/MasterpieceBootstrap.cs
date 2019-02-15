using System;
using System.Collections.Generic;
using System.Threading;
using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace VG.MasterpieceCatalog.Application
{
  public class MasterpieceBootstrap
  {
    public static void Run(string[] args, Action<ContainerBuilder> builder, int port, string connectionString = null)
    {
      MasterpieceStartup.RegisterExternalTypes = builder;
      ThreadPool.QueueUserWorkItem(starte => CreateWebHostBuilder(args, port, connectionString).Build().Run());
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args, int port, string connectionString)
    {
      KeyValuePair<string, string> kv = new KeyValuePair<string, string>("ConnectionStrings:DefaultConnection", connectionString);
      var c = WebHost.CreateDefaultBuilder(args)
        .UseKestrel(f => f.ListenAnyIP(port))
        .UseStartup<MasterpieceStartup>();
      if (connectionString != null)
      {
        c.ConfigureAppConfiguration(conf => conf.AddInMemoryCollection(new[] {kv}));
      }

      return c;
    }
  }
}
