using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Features.Events
{
  [Route("api/events")]
  [ApiController]
  public class EventsController : Controller
  {
    private readonly IEventStore _eventRepository;

    public EventsController(IEventStore eventRepository)
    {
      _eventRepository = eventRepository;
    }

    [HttpGet()]
    public ActionResult<MasterpieceEvent[]> Get([FromQuery]int lastEventId, [FromQuery]int count)
    {
      return _eventRepository.GetFrom(lastEventId, count).Select(f=>new MasterpieceEvent(){ Id = f.Id, Event = f.Data }).ToArray();
    }
  }
}
