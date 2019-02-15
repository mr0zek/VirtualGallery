using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.DeleteMasterpiece
{
  public class DeleteMasterpieceCommand
  {
    public MasterpieceId Id { get; }
    public int? ExpectedVersion { get; }
    
    public DeleteMasterpieceCommand(MasterpieceId id, int? expectedVersion)
    {
      Id = id;
      ExpectedVersion = expectedVersion;
    }
  }
}