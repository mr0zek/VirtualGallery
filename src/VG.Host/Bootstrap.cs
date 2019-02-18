using Microsoft.Extensions.Configuration;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Infrastructure.Migrations;
using VG.MasterpieceCatalog.Perspective;

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

      new MasterpieceDatabaseMigrator().Migrate(connectionString);

      MasterpieceBootstrap.Run(args, builder => { }, 12121);
    }
  }  
}
