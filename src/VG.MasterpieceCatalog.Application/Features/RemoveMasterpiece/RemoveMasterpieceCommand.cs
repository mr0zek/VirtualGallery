using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.RemoveMasterpiece
{
  public class RemoveMasterpieceCommand
  {
    public MasterpieceId Id { get; }
    
    public RemoveMasterpieceCommand(MasterpieceId id)
    {
      Id = id;
    }
  }
}