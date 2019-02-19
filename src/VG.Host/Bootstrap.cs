using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Perspective;
using VG.MasterpieceCatalog.Perspective.Migrations;
using Event = VG.MasterpieceCatalog.Contract.Event;

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
      var eventsUrl = configuration["MasterpieceCatalog:EventsUrl"];

      new PerspectiveDatabaseMigrator().Migrate(connectionString);
      new MasterpieceDatabaseMigrator().Migrate(connectionString);

      ConcurrentQueue<Event> queue = new ConcurrentQueue<Event>();
      MasterpieceBootstrap.Run(args, builder => { }, 12121, queue);
      PerspectiveBootstrap.Run(args, builder => { }, connectionString, queue );
    }
  }  
}
