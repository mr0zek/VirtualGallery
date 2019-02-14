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

    public void Handle(RevokeMasterpieceReservationCommand reservationCommand)
    {
      Domain.Masterpiece m = _masterpieceRepository.Get(reservationCommand.MasterpieceId);
      m.RevokeReservation(reservationCommand.CustomerId);
      _masterpieceRepository.Save(m);
    }
  }
}
