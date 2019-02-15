using System;

namespace VG.MasterpieceCatalog.Contract
{
  public class CreateMasterpieceRequest
  {
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }
    public DateTime Produced { get; set; }
  }
}