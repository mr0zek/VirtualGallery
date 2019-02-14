using System;
using System.Collections.Generic;

namespace VG.MasterpieceCatalog.Application.Features.Events
{
  public interface IEventRepository
  {
    IEnumerable<MasterpieceEvent> Get(Guid startEventId, int count);
  }
}