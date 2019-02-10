using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Application.CreateMasterpiece;

namespace VG.MasterpieceCatalog.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MasterpieceController : Controller
  {
    private readonly IMasterpiecePerspective _masterpiecePerspective;
    private ICommandHandler<CreateMasterpieceCommand> _createMasterpieceHandler;

    public MasterpieceController(IMasterpiecePerspective masterpiecePerspective)
    {
      _masterpiecePerspective = masterpiecePerspective;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<MasterpieceGetModel>> Get()
    {
      return Json(_masterpiecePerspective.GetMany(100));
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<MasterpieceGetModel> Get(Guid id)
    {
      return Json(_masterpiecePerspective.Get(id));
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] MasterpiecePostModel model)
    {
      _createMasterpieceHandler.Handle(new CreateMasterpieceCommand(model.Id, model.Name, model.Price));
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
    }
  }
}
