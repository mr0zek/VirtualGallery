using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Features.CreateMasterpiece
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
    public void Post([FromBody] CreateMasterpieceRequest model)
    {
      _createMasterpieceHandler.Handle(new CreateMasterpieceCommand(model.Id, model.Name, model.Price, model.Produced));
    }
  }
}
