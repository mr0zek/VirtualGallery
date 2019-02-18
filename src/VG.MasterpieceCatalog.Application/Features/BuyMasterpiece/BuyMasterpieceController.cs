using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Features.BuyMasterpiece
{
  [Route("api/masterpieces")]
  [ApiController]
  public class BuyMasterpieceController : Controller
  {
    private readonly ICommandHandler<BuyMasterpieceCommand> _buyMasterpieceHandler;
    
    public BuyMasterpieceController(ICommandHandler<BuyMasterpieceCommand> buyMasterpieceHandler)
    {
      _buyMasterpieceHandler = buyMasterpieceHandler;
    }

    [HttpPost("{id}/buyers")]
    public void PostBuyers(string id, int? expectedVersion, [FromBody] PostBuyerRequest postBuyer)
    {
      _buyMasterpieceHandler.Handle(new BuyMasterpieceCommand(id, postBuyer.CustomerId));
    }
  }
}
