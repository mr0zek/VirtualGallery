using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public class Event
  {
    public int Id { get; set; }
    public int Version { get; set; }
    public IEvent Data { get; set; }

    public Event(int id, int version, IEvent @event)
    {
      Id = id;
      Version = version;
      Data = @event;
    }
  }
}