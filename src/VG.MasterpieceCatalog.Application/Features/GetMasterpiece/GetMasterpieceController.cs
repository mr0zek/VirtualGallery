using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Perspective;

namespace VG.MasterpieceCatalog.Application.Features.GetMasterpiece
{
  [Route("api/masterpieces")]
  [ApiController]
  public class GetMasterpieceController : Controller
  {
    private readonly IMasterpiecePerspectiveRepository _masterpiecePerspectiveRepository;

    public GetMasterpieceController(IMasterpiecePerspectiveRepository masterpiecePerspectiveRepository)
    {
      _masterpiecePerspectiveRepository = masterpiecePerspectiveRepository;
    }

    [HttpGet]
    public async Task<ActionResult<MasterpiecesModel>> GetAsync()
    {
      return await _masterpiecePerspectiveRepository.GetManyAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MasterpieceModel>> GetAsync(string id)
    {
      return Json(await _masterpiecePerspectiveRepository.GetAsync(id));
    }    
  }
}
