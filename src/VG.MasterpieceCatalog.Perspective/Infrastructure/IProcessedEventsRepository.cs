namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public interface IProcessedEventsRepository
  {
    int GetLastProcessedEventId();
    void SetLastProcessedEventId(int id);
  }
}