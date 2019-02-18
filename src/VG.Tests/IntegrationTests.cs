using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Xml;
using Autofac;
using Moq;
using RestEase;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Infrastructure.Migrations;
using VG.Tests.BaseTypes;
using Xunit;


namespace VG.Tests
{
  public class IntegrationTests : DbTestFixture
  {
    public IntegrationTests() : base(@"Server=(local);Database=Test;Integrated Security=true;")
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
    public async void Add_should_persist_masterpiece()
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

      customerRepositoryMock.Setup(f => f.Get(customerId)).Returns(new Customer(true));
      dateTimeProviderMock.Setup(f => f.Now()).Returns(DateTime.Parse("2019-01-01"));

      Thread.Sleep(2000);

      // Act
      var masterpieceApi = RestClient.For<IMasterpieceApi>(masterpieceCatalogUrl);
      await masterpieceApi.CreateMasterpiece(new CreateMasterpieceRequest()
      {
        Id = "m1",
        Name = "Test1",
        Price = 15,
        Produced = DateTime.Parse("2019-01-01")
      });

      var masterPiece = await masterpieceApi.GetMasterPiece("m1");
      Assert.NotNull(masterPiece);
      Assert.Equal("m1", masterPiece.Id);
    }


    [Fact]
    [Trait("Category", "Integration")]
    public async void Remove_should_make_mastepiece_unaviable()
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

      customerRepositoryMock.Setup(f => f.Get(customerId)).Returns(new Customer(true));
      dateTimeProviderMock.Setup(f => f.Now()).Returns(DateTime.Parse("2019-01-01"));

      Thread.Sleep(2000);

      var masterpieceApi = RestClient.For<IMasterpieceApi>(masterpieceCatalogUrl);
      await masterpieceApi.CreateMasterpiece(new CreateMasterpieceRequest()
      {
        Id = "m1",
        Name = "Test1",
        Price = 15,
        Produced = DateTime.Parse("2019-01-01")
      });

      // Act
      await masterpieceApi.RemoveMasterpiece("m1");

      // Assert
      var masterPiece = await masterpieceApi.GetMasterPiece("m1");
      Assert.False(masterPiece.IsAvailable);
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async void Buy_should_make_mastepiece_unaviable()
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

      customerRepositoryMock.Setup(f => f.Get(customerId)).Returns(new Customer(true));
      dateTimeProviderMock.Setup(f => f.Now()).Returns(DateTime.Parse("2019-01-01"));

      Thread.Sleep(2000); 

      var masterpieceApi = RestClient.For<IMasterpieceApi>(masterpieceCatalogUrl);
      await masterpieceApi.CreateMasterpiece(new CreateMasterpieceRequest()
      {
        Id = "m1",
        Name = "Test1",
        Price = 15,
        Produced = DateTime.Parse("2019-01-01")
      });

      // Act
      await masterpieceApi.BuyMasterpiece("m1", new BuyMasterpieceRequest()
      {
        CustomerId = customerId
      });

      // Assert
      var masterPiece = await masterpieceApi.GetMasterPiece("m1");
      Assert.False(masterPiece.IsAvailable);
    }
  }
}
