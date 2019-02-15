using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Autofac;
using RestEase;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Infrastructure;
using VG.Notification;
using VG.Notification.ExternalInterfaces;
using VG.Tests.BaseTypes;
using Xunit;

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

      new DatabaseMigrator().Migrate(ConnectionString);
    }

    [Fact]
    [Trait("Category","Integration")]
    public async void HappyScenario()
    {
      // Arrange     
      int port = 12121;
      MasterpieceBootstrap.Run(new string[0], builder => { }, port, ConnectionString);
      string masterpieceCatalogUrl = $"http://localhost:{port}";
      NotificationBootstrap.Run(new string[0], builder =>
      {
        builder.RegisterType<FakeSmtpClient>().As<ISmtpClient>();
      }, ConnectionString, masterpieceCatalogUrl);      

      // Act
      var masterpieceApi = RestClient.For<IMasterpieceApi>(masterpieceCatalogUrl);
      await masterpieceApi.PostMasterpiece(new CreateMasterpieceRequest()
      {
        Id = "m1",
        Name = "Test1",
        Price = 15
      });

      await masterpieceApi.PostMasterpieceReservation("m1", new MasterpieceReservationRequest()
      {
        CustomerId = "123"
      });

      Assert.True(FakeSmtpClient.Count == 1);

    }
  }

  public class MasterpieceReservationRequest
  {
    public string CustomerId { get; set; }
  }

  public interface IMasterpieceApi
  {
    [Post("api/masterpieces")]
    Task PostMasterpiece([Body]CreateMasterpieceRequest request);

    [Post("api/masterpieces/{id}/reservation")]
    Task PostMasterpieceReservation([Path]string id, [Body]MasterpieceReservationRequest masterpieceReservationRequest);
  }

  public class CreateMasterpieceRequest
  {
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }
  }
}
