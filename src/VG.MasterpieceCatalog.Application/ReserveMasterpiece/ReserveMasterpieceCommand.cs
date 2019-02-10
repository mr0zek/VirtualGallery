using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.ReserveMasterpiece
{
  public class ReserveMasterpieceCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustormerId { get; set; }
  }
}