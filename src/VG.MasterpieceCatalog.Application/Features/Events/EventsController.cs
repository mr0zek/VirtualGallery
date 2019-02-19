using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VG.MasterpieceCatalog.Infrastructure.SqlEventStore;

namespace VG.MasterpieceCatalog.Application.Features.Events
{
  [Route("api/events")]
  [ApiController]
  public class EventsController : Controller
  {
    private readonly IEventStore _eventRepository;
    private readonly IEventsConverter _converter;

    public EventsController(IEventStore eventRepository, IEventsConverter converter)
    {
      _eventRepository = eventRepository;
      _converter = converter;
    }

    [HttpGet()]
    public ActionResult<Contract.Event[]> Get([FromQuery]int? lastEventId, [FromQuery]int? count)
    {
      if (count == null)
      {
        count = 100;
      }
      return Json(_eventRepository.GetFrom(lastEventId, count.Value)
        .Select(f => _converter.Convert(f)).ToArray(), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects });
    }
  }
}
