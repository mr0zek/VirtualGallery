using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.RemoveMasterpiece
{
  public class RemoveMasterpieceHandler : ICommandHandler<RemoveMasterpieceCommand>
  {
    private readonly IMasterpieceRepository _masterpieceRepository;

    public RemoveMasterpieceHandler(IMasterpieceRepository masterpieceRepository)
    {
      _masterpieceRepository = masterpieceRepository;
    }

    public void Handle(RemoveMasterpieceCommand command)
    {
      Masterpiece m = _masterpieceRepository.Get(command.Id);
      m.Remove();
      _masterpieceRepository.Save(m);
    }
  }
}
