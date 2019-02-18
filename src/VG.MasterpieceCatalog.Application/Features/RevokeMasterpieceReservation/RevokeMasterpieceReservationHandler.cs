using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.RevokeMasterpieceReservation
{
  public class RevokeMasterpieceReservationHandler : ICommandHandler<RevokeMasterpieceReservationCommand>
  {
    private readonly IMasterpieceRepository _masterpieceRepository;

    public RevokeMasterpieceReservationHandler(IMasterpieceRepository masterpieceRepository)
    {
      _masterpieceRepository = masterpieceRepository;
    }

    public void Handle(RevokeMasterpieceReservationCommand command)
    {
      Domain.Masterpiece m = _masterpieceRepository.Get(command.MasterpieceId);
      m.RevokeReservation(command.CustomerId);
      _masterpieceRepository.Save(m);
    }
  }
}
