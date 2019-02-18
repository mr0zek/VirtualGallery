namespace VG.MasterpieceCatalog.Contract
{
  public class RevokedMasterpieceReservationEvent : Event
  {
    public string CustomerId { get; set; }
  }
}