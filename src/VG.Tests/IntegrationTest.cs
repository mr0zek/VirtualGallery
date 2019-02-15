using System.Threading.Tasks;
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
      new DatabaseMigrator().Migrate(ConnectionString);
    }

    [Fact]
    public async void Test1()
    {
      // Arrange     
      int port = 12121;
      MasterpieceBootstrap.Run(new string[0], builder => { }, port);
      string masterpieceCatalogUrl = $"http://localhost:{port}";
      NotificationBootstrap.Run(new string[0], builder =>
      {
        builder.RegisterType<FakeSmtpClient>().As<ISmtpClient>();
      }, ConnectionString, masterpieceCatalogUrl);      

      // Act
      var masterpieceApi = RestClient.For<IMasterpieceApi>(masterpieceCatalogUrl);
      await masterpieceApi.PostMasterpiece(new MasterpieceCreateRequest()
      {
        MasterpieceId = "m1",
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
    Task PostMasterpiece([Body]MasterpieceCreateRequest request);

    [Post("api/masterpieces/{id}/reservation")]
    Task PostMasterpieceReservation([Path]string id, [Body]MasterpieceReservationRequest masterpieceReservationRequest);
  }

  public class MasterpieceCreateRequest
  {
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string MasterpieceId { get; set; }
  }
}
