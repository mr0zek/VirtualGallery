using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application
{
  public class BuyMasterpieceCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustormerId { get; set; }
  }
}