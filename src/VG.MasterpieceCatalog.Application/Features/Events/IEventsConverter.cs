using VG.MasterpieceCatalog.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Features.Events
{
  public interface IEventsConverter
  {
    Contract.Event Convert(Event @event);
  }
}