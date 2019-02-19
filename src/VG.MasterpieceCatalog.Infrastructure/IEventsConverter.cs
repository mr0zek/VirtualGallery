using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  internal interface IEventsConverter
  {
    Event Convert(IEvent @event);
  }
}