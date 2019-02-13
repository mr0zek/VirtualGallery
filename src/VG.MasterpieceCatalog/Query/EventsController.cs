using System;
using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Controllers;
using VG.MasterpieceCatalog.Perspective;

namespace VG.MasterpieceCatalog.Query
{
  [Route("api/events")]
  [ApiController]
  public class EventsController : Controller
  {
    private readonly IEventRepository _eventRepository;

    public EventsController(IEventRepository eventRepository)
    {
      _eventRepository = eventRepository;
    }

    [HttpGet()]
    public ActionResult Get([FromQuery]Guid startEventId, [FromQuery]int count)
    {
      return Json(_eventRepository.Get(startEventId, count));
    }
  }
}
