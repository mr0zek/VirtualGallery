using Microsoft.Extensions.Configuration;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Perspective;
using VG.MasterpieceCatalog.Perspective.Migrations;

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

      new PerspectiveDatabaseMigrator().Migrate(connectionString);
      new MasterpieceDatabaseMigrator().Migrate(connectionString);

      MasterpieceBootstrap.Run(args, builder => { }, 12121);
      PerspectiveBootstrap.Run(args, builder => { }, connectionString, masterpieceCatalogUrl);
    }
  }  
}
