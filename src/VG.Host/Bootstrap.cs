using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Infrastructure;
using VG.Notification;

namespace VG.Host
{
  public class Bootstrap
  {
    public void Run(string[] args)
    {
      var confBuilder = new ConfigurationBuilder()
        .AddJsonFile("appSettings.json");
      var configuration = confBuilder.Build();
      var connectionString = configuration["ConnectionStrings:DefaultConnection"];
      var masterpieceCatalogUrl = configuration["MasterpieceCatoalog:Port"];

      new DatabaseMigrator().Migrate(connectionString);

      MasterpieceBootstrap.Run(args, builder => { }, 12121);
      NotificationBootstrap.Run(args, builder => { }, connectionString, masterpieceCatalogUrl);
    }
  }  
}
