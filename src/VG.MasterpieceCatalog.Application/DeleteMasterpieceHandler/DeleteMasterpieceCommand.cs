using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.DeleteMasterpieceHandler
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