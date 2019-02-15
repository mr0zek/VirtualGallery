using Newtonsoft.Json;

namespace VG.MasterpieceCatalog.Contract
{
  [JsonConverter(typeof(MasterpieceEventConverter))]
  public class MasterpieceEvent
  {
    public int Id { get; set; }
    public string Type { get; set; }
    public int Version { get; set; }
    public IEvent Event { get; set; }
  }
}