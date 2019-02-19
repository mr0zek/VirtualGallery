using System;
using Newtonsoft.Json;

namespace VG.MasterpieceCatalog.Contract
{
  public class Event
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string AggregateId { get; set; }
    public int Version { get; set; }
  }
}