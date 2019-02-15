using System;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.CreateMasterpiece
{
  public class CreateMasterpieceCommand
  {
    public MasterpieceId Id { get; }
    public string Name { get; }
    public Money Price { get; }
    public DateTime Produced { get; set; }

    public CreateMasterpieceCommand(MasterpieceId id, string name, Money price, DateTime produced)
    {
      Id = id;
      Name = name;
      Price = price;
      Produced = produced;
    }
  }
}