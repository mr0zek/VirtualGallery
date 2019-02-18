using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.Features.CreateMasterpiece;
using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.DeleteMasterpiece
{
  [Route("api/masterpieces")]
  [ApiController]
  public class DeleteMasterpieceController : Controller
  {
    private readonly ICommandHandler<DeleteMasterpieceCommand> _deleteMasterpieceHandler;
    
    public DeleteMasterpieceController(ICommandHandler<DeleteMasterpieceCommand> deleteMasterpieceHandler)
    {
      _deleteMasterpieceHandler = deleteMasterpieceHandler;
    }

    [HttpDelete("{id}")]
    public void Post(string id)
    {
      _deleteMasterpieceHandler.Handle(new DeleteMasterpieceCommand(id));
    }
  }
}
