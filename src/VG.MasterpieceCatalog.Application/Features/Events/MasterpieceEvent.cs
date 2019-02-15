using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Application.Features.Events
{
  public class MasterpieceEvent
  {
    public int Id { get; set; }
    public IEvent Event { get; set; }
  }
}