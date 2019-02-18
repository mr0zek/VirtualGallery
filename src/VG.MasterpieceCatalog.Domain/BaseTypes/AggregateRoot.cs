using System;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public class AggregateRoot
  {
    public string Id { get; protected set; }
    public int Version { get; internal set; }
  }
}