using System;
using System.Collections.Generic;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public class DatabaseMigrator
  {
    public void Migrate(string connectionString)
    {
      ServiceCollection serviceCollection = new ServiceCollection();
      var sp = serviceCollection.AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
          .AddSqlServer()
          .WithGlobalConnectionString(connectionString)
          .ScanIn(typeof(DatabaseMigrator).Assembly).For.Migrations())
          .AddLogging(lb => lb.AddFluentMigratorConsole())
          .BuildServiceProvider(false);

      sp.GetService<IMigrationRunner>().MigrateUp();
    }    
  }
}
