using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using VG.MasterpieceCatalog.Application.Infrastructure.Migrations;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;

namespace VG.MasterpieceCatalog.Application.Infrastructure
{
  public class DatabaseMigrator
  {
    public static string ParamsConnectionString { get; set; }

    public void Migrate(Dictionary<string, string> @params)
    {
      if (!@params.ContainsKey(ParamsConnectionString))
      {
        throw new ArgumentException($"Parameter [{ParamsConnectionString}] wasn't supplied");
      }

      ServiceCollection serviceCollection = new ServiceCollection();
      var sp = serviceCollection.AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
          .AddSqlServer()
          .WithGlobalConnectionString(@params[ParamsConnectionString])
          .ScanIn(typeof(DatabaseMigrator).Assembly).For.Migrations())
          .AddLogging(lb => lb.AddFluentMigratorConsole())
          .BuildServiceProvider(false);

      sp.GetService<IMigrationRunner>().MigrateUp();
    }    
  }
}
