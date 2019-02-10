using System.Collections.Generic;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public interface IEventsCollectionAccesor
  {
    IEnumerable<IEvent> GetUncommittedChanges();
  }
}