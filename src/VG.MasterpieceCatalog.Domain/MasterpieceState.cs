using System;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceState
  {
    public string Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public DateTime Produced { get; }
    public int Version { get; set; }
    public bool IsRemoved { get; set; }

    public MasterpieceState()
    {
    }

    public MasterpieceState(string id, string name, Money price, DateTime produced, int version, bool isRemoved)
    {
      Version = version;
      IsRemoved = isRemoved;
      Id = id;
      Name = name;
      Price = price;
      Produced = produced;
    }
  }
}