using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace VG.MasterpieceCatalog.Application.Features.Events
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
    public ActionResult<MasterpieceEvent[]> Get([FromQuery]Guid startEventId, [FromQuery]int count)
    {
      return _eventRepository.Get(startEventId, count).ToArray();
    }
  }
}
