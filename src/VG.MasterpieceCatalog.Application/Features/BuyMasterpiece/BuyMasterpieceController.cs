using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Features.BuyMasterpiece
{
  [Route("api/masterpieces")]
  [ApiController]
  public class BuyMasterpieceController : Controller
  {
    public BuyMasterpieceController()
    {
    }

    [HttpPost("{id}/buyers")]
    public void PostBuyers(string id, int? expectedVersion, [FromBody] PostBuyerRequest postBuyer)
    {
     
    }
  }
}
