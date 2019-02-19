using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.RemoveMasterpiece
{
  public class RemoveMasterpieceCommand
  {
    public MasterpieceId Id { get; }
    public int? ExpectedVersion { get; }
    
    public RemoveMasterpieceCommand(MasterpieceId id, int? expectedVersion)
    {
      Id = id;
      ExpectedVersion = expectedVersion;
    }
  }
}