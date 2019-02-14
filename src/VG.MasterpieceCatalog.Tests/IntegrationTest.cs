using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.AspNetCore;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Components.Notification;
using VG.MasterpieceCatalog.Components.Notification.ExternalInterfaces;
using VG.MasterpieceCatalog.Tests.BaseTypes;
using Xunit;

namespace VG.MasterpieceCatalog.Tests
{
  public class IntegrationTest : DbTestFixture
  {
    public IntegrationTest() : base(@"Server=(local);Database=Test;Integrated Security=true;")
    {
      new DatabaseMigrator().Migrate(new Dictionary<string, string>
      {
        { DatabaseMigrator.ParamsConnectionString, ConnectionString }
      });
    }

    [Fact]
    public void Test1()
    {
      // Arrange     
      MasterpieceBootstrap.Run(new string[0], builder => { });
      NotificationBootstrap.Run(new string[0], builder =>
      {
        builder.RegisterType<FakeSmtpClient>().As<ISmtpClient>();
      });      

      // Act


    }    
  }
}
