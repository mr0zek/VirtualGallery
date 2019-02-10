using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.RevokeMasterpieceReservation
{
  public class RevokeMasterpieceCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustomerId { get; set; }
  }
}