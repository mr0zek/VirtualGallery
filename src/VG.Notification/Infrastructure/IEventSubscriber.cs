namespace VG.Notification.Infrastructure
{
  public interface IEventSubscriber
  {
    int ProcessEvents(int eventsCount);
  }
}