using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public class Event
  {
    public int Id { get; set; }
    public IEvent Data { get; set; }

    public Event(int id, IEvent @event)
    {
      Id = id;
      Data = @event;
    }
  }
}