using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Components.MasterpiecePerspective.Contract;
using VG.MasterpieceCatalog.Controllers;

namespace VG.MasterpieceCatalog.Components.MasterpiecePerspective
{
  [Route("api/[controller]")]
  [ApiController]
  public class MasterpieceController : Controller
  {
    private readonly IMasterpiecePerspective _masterpiecePerspective;

    public MasterpieceController(IMasterpiecePerspective masterpiecePerspective)
    {
      _masterpiecePerspective = masterpiecePerspective;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<MasterpiecePerspectiveResponse>> Get()
    {
      return Json(_masterpiecePerspective.GetMany(100));
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<MasterpiecePerspectiveResponse> Get(Guid id)
    {
      return Json(_masterpiecePerspective.Get(id));
    }    
  }
}
