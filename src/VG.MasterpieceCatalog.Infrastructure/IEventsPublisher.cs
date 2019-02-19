using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  internal interface IEventsPublisher
  {
    void Publish(IEnumerable<IEvent> events);
  }
}