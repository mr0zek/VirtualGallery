namespace VG.Notification.Infrastructure
{
  public interface IProcessedEventsRepository
  {
    int GetLastProcessedEventId();
    void SetLastProcessedEventId(int id);
  }
}