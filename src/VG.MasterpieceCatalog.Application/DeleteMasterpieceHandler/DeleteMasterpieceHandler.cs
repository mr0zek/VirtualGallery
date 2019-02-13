using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Application.CreateMasterpiece;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.DeleteMasterpieceHandler
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
      Masterpiece m = _masterpieceRepository.Get(command.Id);
      _masterpieceRepository.Delete(m);
    }
  }
}
