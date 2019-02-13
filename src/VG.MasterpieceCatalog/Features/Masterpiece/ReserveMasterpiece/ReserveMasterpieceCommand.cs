using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Features.Masterpiece.ReserveMasterpiece
{
  public class ReserveMasterpieceCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustomerId { get; }
    public CustomerId CustormerId { get; set; }

    public ReserveMasterpieceCommand(MasterpieceId masterpieceId, CustomerId customerId)
    {
      MasterpieceId = masterpieceId;
      CustomerId = customerId;
    }
  }
}