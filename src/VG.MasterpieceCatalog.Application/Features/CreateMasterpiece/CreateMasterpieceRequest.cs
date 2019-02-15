using System;

namespace VG.MasterpieceCatalog.Application.Features.CreateMasterpiece
{
  public class CreateMasterpieceRequest

  {
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }
  }
}