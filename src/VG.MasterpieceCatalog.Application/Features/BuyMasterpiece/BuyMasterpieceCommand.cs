using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.BuyMasterpiece
{
  public class BuyMasterpieceCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustomerId { get; }
    public int? ExpectedVersion { get; }

    public BuyMasterpieceCommand(MasterpieceId masterpieceId, CustomerId customerId, int? expectedVersion)
    {
      MasterpieceId = masterpieceId;
      CustomerId = customerId;
      ExpectedVersion = expectedVersion;
    }
  }
}