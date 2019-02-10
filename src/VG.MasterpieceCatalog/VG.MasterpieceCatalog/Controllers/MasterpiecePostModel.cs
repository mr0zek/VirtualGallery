using System;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Controllers
{
  public class MasterpiecePostModel

  {
    public decimal Price { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }
  }
}