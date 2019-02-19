using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VG.MasterpieceCatalog.Contract;

namespace VG.MasterpieceCatalog.Application
{
  public class MasterpieceBootstrap
  {
    public static void Run(string[] args, Action<ContainerBuilder> builder, int port, ConcurrentQueue<Event> queue,
      string connectionString = null)
    {
      MasterpieceStartup.RegisterExternalTypes = builder;
      MasterpieceStartup.Queue = queue;

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
