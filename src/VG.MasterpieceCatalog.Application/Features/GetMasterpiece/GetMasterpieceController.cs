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
    private readonly IMasterpiecePerspective _masterpiecePerspective;

    public GetMasterpieceController(IMasterpiecePerspective masterpiecePerspective)
    {
      _masterpiecePerspective = masterpiecePerspective;
    }

    [HttpGet]
    public ActionResult<IEnumerable<MasterpiecePerspectiveResponse>> Get()
    {
      return Json(_masterpiecePerspective.GetMany(100));
    }

    [HttpGet("{id}")]
    public ActionResult<MasterpiecePerspectiveResponse> Get(Guid id)
    {
      return Json(_masterpiecePerspective.Get(id));
    }    
  }
}
