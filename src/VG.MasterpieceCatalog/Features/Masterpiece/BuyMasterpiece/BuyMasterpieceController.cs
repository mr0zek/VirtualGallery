using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Command;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Features.Masterpiece.BuyMasterpiece
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
    public void PostBuyers(string id, [FromBody] PostBuyerRequest postBuyer)
    {
      _buyMasterpieceHandler.Handle(new BuyMasterpieceCommand(id, postBuyer.CustomerId));
    }
  }
}
