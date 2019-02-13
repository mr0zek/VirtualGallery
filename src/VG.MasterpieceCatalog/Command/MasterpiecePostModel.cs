using System;

namespace VG.MasterpieceCatalog.Command
{
  public class MasterpiecePostModel

  {
    public decimal Price { get; set; }
    public string Name { get; set; }
    public Guid MasterpieceId { get; set; }
  }
}