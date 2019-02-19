using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Features.RemoveMasterpiece
{
  [Route("api/masterpieces")]
  [ApiController]
  public class RemoveMasterpieceController : Controller
  {
    private readonly ICommandHandler<RemoveMasterpieceCommand> _removeMasterpieceHandler;
    
    public RemoveMasterpieceController(ICommandHandler<RemoveMasterpieceCommand> removeMasterpieceHandler)
    {
      _removeMasterpieceHandler = removeMasterpieceHandler;
    }

    [HttpDelete("{id}")]
    public void Post(string id)
    {
      _removeMasterpieceHandler.Handle(new RemoveMasterpieceCommand(id));
    }
  }
}
