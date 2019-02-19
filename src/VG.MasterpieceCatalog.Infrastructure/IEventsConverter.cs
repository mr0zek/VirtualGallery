using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  internal interface IEventsConverter
  {
    object Convert(IEvent @event);
  }
}