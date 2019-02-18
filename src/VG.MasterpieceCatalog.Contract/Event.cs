using Newtonsoft.Json;

namespace VG.MasterpieceCatalog.Contract
{
  public class Event
  {
    public int Id { get; set; }
    public string AggregateId { get; set; }
    public int Version { get; set; }
  }
}