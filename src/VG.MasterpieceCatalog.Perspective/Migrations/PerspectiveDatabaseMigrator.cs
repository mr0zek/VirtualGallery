using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace VG.MasterpieceCatalog.Perspective.Migrations
{
  public class PerspectiveDatabaseMigrator
  {
    public void Migrate(string connectionString)
    {
      ServiceCollection serviceCollection = new ServiceCollection();
      var sp = serviceCollection.AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
          .AddSqlServer()
          .WithGlobalConnectionString(connectionString)
          .ScanIn(typeof(PerspectiveDatabaseMigrator).Assembly).For.Migrations())
          .AddLogging(lb => lb.AddFluentMigratorConsole())
          .BuildServiceProvider(false);

      sp.GetService<IMigrationRunner>().MigrateUp();
    }    
  }
}
