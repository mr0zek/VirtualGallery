using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.DeleteMasterpiece
{
  public class DeleteMasterpieceHandler : ICommandHandler<DeleteMasterpieceCommand>
  {
    private readonly IMasterpieceRepository _masterpieceRepository;

    public DeleteMasterpieceHandler(IMasterpieceRepository masterpieceRepository)
    {
      _masterpieceRepository = masterpieceRepository;
    }

    public void Handle(DeleteMasterpieceCommand command)
    {
      Domain.Masterpiece m = _masterpieceRepository.Get(command.Id);
      _masterpieceRepository.Delete(m);
    }
  }
}
