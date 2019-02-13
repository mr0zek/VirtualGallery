using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Features.Masterpiece.DeleteMasterpieceHandler
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
