using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Autofac;
using Moq;
using RestEase;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Perspective;
using VG.Tests.BaseTypes;
using Xunit;
using MasterpieceBoughtEvent = VG.MasterpieceCatalog.Contract.MasterpieceBoughtEvent;
using MasterpieceCreatedEvent = VG.MasterpieceCatalog.Contract.MasterpieceCreatedEvent;
using MasterpieceRemovedEvent = VG.MasterpieceCatalog.Contract.MasterpieceRemovedEvent;
using MasterpieceReservedEvent = VG.MasterpieceCatalog.Contract.MasterpieceReservedEvent;
using RevokedMasterpieceReservationEvent = VG.MasterpieceCatalog.Contract.RevokedMasterpieceReservationEvent;


namespace VG.Tests
{
  public class IntegrationTest : DbTestFixture
  {
    public IntegrationTest() : base(@"Server=(local);Database=Test;Integrated Security=true;")
    {
      XmlDocument log4netConfig = new XmlDocument();
      log4netConfig.Load(File.OpenRead("log4net.config"));

      var repo = log4net.LogManager.CreateRepository(
        Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
      
      log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

      new MasterpieceDatabaseMigrator().Migrate(ConnectionString);
    }

    [Fact]
    [Trait("Category","Integration")]
    public async void HappyScenario()
    {
      // Arrange     
      int port = 12121;
      string customerId = "CustId1234";

      Mock<ICustomerRepository> customerRepositoryMock = new Mock<ICustomerRepository>();
      Mock<IDateTimeProvider> dateTimeProviderMock = new Mock<IDateTimeProvider>();

      MasterpieceBootstrap.Run(new string[0], builder =>
        {
          builder.RegisterInstance(customerRepositoryMock.Object).AsImplementedInterfaces();
          builder.RegisterInstance(dateTimeProviderMock.Object).AsImplementedInterfaces();
        }, port, ConnectionString);
      string masterpieceCatalogUrl = $"http://localhost:{port}";
      PerspectiveBootstrap.Run(new string[0], builder => { }, ConnectionString, masterpieceCatalogUrl);

      customerRepositoryMock.Setup(f => f.Get(customerId)).Returns(new Customer(true));
      dateTimeProviderMock.Setup(f => f.Now()).Returns(DateTime.Parse("2019-01-01"));

      // Act
      var masterpieceApi = RestClient.For<IMasterpieceApi>(masterpieceCatalogUrl);
      await masterpieceApi.CreateMasterpiece(new CreateMasterpieceRequest()
      {
        Id = "m1",
        Name = "Test1",
        Price = 15,
        Produced = DateTime.Parse("2019-01-01")
      });

      await masterpieceApi.ReserveMasterpiece("m1", new ReserveMasterpieceRequest(){CustomerId = customerId});

      await masterpieceApi.RevokeMasterpieceReservation("m1", customerId);

      await masterpieceApi.BuyMasterpiece("m1", new BuyMasterpieceRequest(){CustomerId = customerId});

      await masterpieceApi.DeleteMasterpiece("m1");

      var masterpieceEventsApi = RestClient.For<IMasterpieceEventsApi>(masterpieceCatalogUrl);


      var result = await masterpieceEventsApi.GetEventsAsync(null,10);

      // Assert
      Assert.Equal(5,result.Length);
      Assert.IsType<MasterpieceCreatedEvent>(result[0]);
      Assert.IsType<MasterpieceReservedEvent>(result[1]);
      Assert.IsType<RevokedMasterpieceReservationEvent>(result[2]);
      Assert.IsType<MasterpieceBoughtEvent>(result[3]);
      Assert.IsType<MasterpieceRemovedEvent>(result[4]);
    }
  }
}
