using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.BuyMasterpiece
{
  public class BuyMasterpieceCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustomerId { get; }
    public CustomerId CustormerId { get; set; }
    public BuyMasterpieceCommand(MasterpieceId masterpieceId, CustomerId customerId)
    {
      MasterpieceId = masterpieceId;
      CustomerId = customerId;
    }
  }
}