﻿using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Command;
using VG.MasterpieceCatalog.Controllers;

namespace VG.MasterpieceCatalog.Features.Masterpiece.CreateMasterpiece
{
  [Route("api/masterpieces")]
  [ApiController]
  public class CreateMasterpieceCommandController : Controller
  {
    private readonly ICommandHandler<CreateMasterpieceCommand> _createMasterpieceHandler;
    
    public CreateMasterpieceCommandController(ICommandHandler<CreateMasterpieceCommand> createMasterpieceHandler)
    {
      _createMasterpieceHandler = createMasterpieceHandler;
    }

    [HttpPost]
    [ProducesResponseType(500)]
    public void Post([FromBody] MasterpiecePostModel model)
    {
      _createMasterpieceHandler.Handle(new CreateMasterpieceCommand(model.MasterpieceId, model.Name, model.Price));
    }
  }
}
