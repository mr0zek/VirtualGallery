using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.RevokeMasterpieceReservation
{
  public class RevokeMasterpieceHandler : ICommandHandler<RevokeMasterpieceCommand>
  {
    private readonly IMasterpieceRepository _masterpieceRepository;

    public RevokeMasterpieceHandler(IMasterpieceRepository masterpieceRepository)
    {
      _masterpieceRepository = masterpieceRepository;
    }

    public void Handle(RevokeMasterpieceCommand command)
    {
      Masterpiece m = _masterpieceRepository.Get(command.MasterpieceId);
      m.RevokeReservation(command.CustomerId);
      _masterpieceRepository.Save(m);
    }
  }
}
