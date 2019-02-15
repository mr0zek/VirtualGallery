using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public interface IEventStore
  {
    void Save(string aggregateId, IEnumerable<IEvent> events);

    IEnumerable<Event> GetFrom(int lastEventId, int count);

    IEnumerable<IEvent> Load(string aggregateId);
  }
}