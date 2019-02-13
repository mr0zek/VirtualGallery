using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Controllers;
using VG.MasterpieceCatalog.Perspective;

namespace VG.MasterpieceCatalog.Query
{
  [Route("api/masterpieces")]
  [ApiController]
  public class MasterpieceQueryController : Controller
  {
    private readonly IMasterpiecePerspective _masterpiecePerspective;
    
    public MasterpieceQueryController(IMasterpiecePerspective masterpiecePerspective)
    {
      _masterpiecePerspective = masterpiecePerspective;
    }

    [HttpGet]
    public ActionResult<IEnumerable<MasterpieceGetModel>> Get()
    {
      return Json(_masterpiecePerspective.GetMany(100));
    }

    [HttpGet("{id}")]
    public ActionResult<MasterpieceGetModel> Get(Guid id)
    {
      return Json(_masterpiecePerspective.Get(id));
    }
  }
}
