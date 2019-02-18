using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<MasterpiecesModel> Get()
    {
      return _masterpiecePerspectiveRepository.GetMany();
    }

    [HttpGet("{id}")]
    public ActionResult<MasterpieceModel> Get(string id)
    {
      return Json(_masterpiecePerspectiveRepository.Get(id));
    }    
  }
}
