using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.Features.CreateMasterpiece;
using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.ReserveMasterpiece
{
  [Route("api/masterpieces")]
  [ApiController]
  public class ReserveMasterpieceController : Controller
  {
    private readonly ICommandHandler<ReserveMasterpieceCommand> _reserveMasterpieceHandler;
    
    public ReserveMasterpieceController(ICommandHandler<ReserveMasterpieceCommand> reserveMasterpieceHandler)
    {
      _reserveMasterpieceHandler = reserveMasterpieceHandler;
    }

    [HttpPost("{id}.{expectedVersion?}/reservations")]
    public void Post(string id, int? expectedVersion, [FromBody] ReserveMasterpieceRequest request)
    {
      _reserveMasterpieceHandler.Handle(new ReserveMasterpieceCommand(id, request.CustomerId, expectedVersion));
    }
  }
}
