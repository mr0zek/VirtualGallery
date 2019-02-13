using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Features.Masterpiece.DeleteMasterpieceHandler
{
  public class DeleteMasterpieceCommand
  {
    public MasterpieceId Id { get; }
    
    public DeleteMasterpieceCommand(MasterpieceId id)
    {
      Id = id;
    }
  }
}