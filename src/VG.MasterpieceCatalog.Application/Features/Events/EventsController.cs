using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VG.MasterpieceCatalog.Infrastructure.SqlEventStore;

namespace VG.MasterpieceCatalog.Application.Features.Events
{
  [Route("api/events")]
  [ApiController]
  public class EventsController : Controller
  {
    private readonly IEventStore _eventRepository;
      private IEventsConverter _converter;

      public EventsController(IEventStore eventRepository)
    {
      _eventRepository = eventRepository;
    }

    [HttpGet()]
    public ActionResult<Contract.Event[]> Get([FromQuery]int? lastEventId, [FromQuery]int? count)
    {
      if (count == null)
      {
        count = 100;
      }      
      return _eventRepository.GetFrom(lastEventId, count.Value)
        .Select(f=> _converter.Convert(f)).ToArray();
    }
  }
}
