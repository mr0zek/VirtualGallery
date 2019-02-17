namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public interface IEventSubscriber
  {
    int ProcessEvents(int eventsCount);
  }
}