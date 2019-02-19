using System.Collections.Generic;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public interface IEventsAccesor
  {
    IEnumerable<IEvent> GetEvents();
  }
}