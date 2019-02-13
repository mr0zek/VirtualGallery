using System;
using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Controllers;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Features.Masterpiece.BuyMasterpiece;
using VG.MasterpieceCatalog.Features.Masterpiece.CreateMasterpiece;
using VG.MasterpieceCatalog.Features.Masterpiece.DeleteMasterpieceHandler;
using VG.MasterpieceCatalog.Features.Masterpiece.ReserveMasterpiece;
using VG.MasterpieceCatalog.Features.Masterpiece.RevokeMasterpieceReservation;

namespace VG.MasterpieceCatalog.Command
{
  [Route("api/masterpieces")]
  [ApiController]
  public class MasterpieceCommandController : Controller
  {
    private readonly ICommandHandler<ReserveMasterpieceCommand> _reserveMasterpieceHandler;
    private readonly ICommandHandler<RevokeMasterpieceReservationCommand> _revokeMasterpieceReservationHandler;
    private ICommandHandler<DeleteMasterpieceCommand> _deleteMasterpieceHandler;

    public MasterpieceCommandController(
      ICommandHandler<BuyMasterpieceCommand> buyMasterpieceHandler,
      ICommandHandler<ReserveMasterpieceCommand> reserveMasterpieceHandler, 
      ICommandHandler<RevokeMasterpieceReservationCommand> revokeMasterpieceReservationHandler)
    {
      _reserveMasterpieceHandler = reserveMasterpieceHandler;
      _revokeMasterpieceReservationHandler = revokeMasterpieceReservationHandler;
    }

    [HttpPost("{masterpieceId}/reserved/{customerId}")]
    public void PostClients([FromRoute]MasterpieceId masterpieceId, [FromRoute]CustomerId customerId)
    {
      _reserveMasterpieceHandler.Handle(new ReserveMasterpieceCommand(masterpieceId, customerId));
    }

    [HttpDelete("{masterpieceId}/reserved/{customerId}")]
    public void DeleteClients([FromRoute]string masterpieceId, [FromRoute]string customerId)
    {
      _revokeMasterpieceReservationHandler.Handle(new RevokeMasterpieceReservationCommand(masterpieceId, customerId));
    }

    [HttpPut("{masterpieceId}")]
    public void Put([FromRoute]MasterpieceId masterpieceId, [FromBody] MasterpiecePostModel value)
    {
    }

    [HttpDelete("{masterpieceId}")]
    public void Delete([FromRoute]MasterpieceId masterpieceId)
    {
      //_deleteMasterpieceHandler.Handle(new DeleteMasterpieceCommad())
    }
  }
}
