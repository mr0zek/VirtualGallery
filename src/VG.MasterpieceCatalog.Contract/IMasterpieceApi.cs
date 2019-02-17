using System.Threading.Tasks;
using RestEase;

namespace VG.MasterpieceCatalog.Contract
{
  public interface IMasterpieceApi
  {
    [Post("api/masterpieces")]
    Task CreateMasterpiece([Body]CreateMasterpieceRequest request);

    [Delete("api/masterpieces/{id}")]
    Task DeleteMasterpiece([Path]string id);

    [Post("api/masterpieces/{id}/reservations")]
    Task ReserveMasterpiece([Path]string id, [Body]ReserveMasterpieceRequest request);

    [Delete("api/masterpieces/{id}/reservations/{customerId}")]
    Task RevokeMasterpieceReservation([Path]string id, [Path]string customerId);

    [Post("api/masterpieces/{id}/buyers")]
    Task BuyMasterpiece([Path]string id, [Body]BuyMasterpieceRequest request);
  }
}