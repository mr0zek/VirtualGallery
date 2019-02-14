using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.DeleteMasterpiece
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