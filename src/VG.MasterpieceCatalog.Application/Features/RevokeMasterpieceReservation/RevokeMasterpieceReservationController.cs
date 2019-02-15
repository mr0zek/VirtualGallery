using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.Features.CreateMasterpiece;
using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.RevokeMasterpieceReservation
{
  [Route("api/masterpieces")]
  [ApiController]
  public class RevokeMasterpieceReservationController : Controller
  {
    private readonly ICommandHandler<RevokeMasterpieceReservationCommand> _revokeMasterpieceReservationHandler;
    
    public RevokeMasterpieceReservationController(ICommandHandler<RevokeMasterpieceReservationCommand> revokeMasterpieceReservationHandler)
    {
      _revokeMasterpieceReservationHandler = revokeMasterpieceReservationHandler;
    }

    [HttpDelete("{id}/reservation/{customerId}")]
    public void Post(string id, string customerId)
    {
      _revokeMasterpieceReservationHandler.Handle(new RevokeMasterpieceReservationCommand(id, customerId));
    }
  }
}
