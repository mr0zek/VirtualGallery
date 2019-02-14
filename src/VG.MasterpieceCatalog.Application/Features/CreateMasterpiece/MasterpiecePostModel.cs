using System;

namespace VG.MasterpieceCatalog.Application.Features.CreateMasterpiece
{
  public class MasterpiecePostModel

  {
    public decimal Price { get; set; }
    public string Name { get; set; }
    public Guid MasterpieceId { get; set; }
  }
}