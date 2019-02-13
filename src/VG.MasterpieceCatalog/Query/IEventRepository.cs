using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Query
{
  public interface IEventRepository
  {
    IEnumerable<IEvent> Get(Guid startEventId, int count);
  }
}