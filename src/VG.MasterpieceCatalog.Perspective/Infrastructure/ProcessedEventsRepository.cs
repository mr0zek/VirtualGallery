namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  class ProcessedEventsRepository : IProcessedEventsRepository
  {
    private int _lastProcessedEventId;
    public int GetLastProcessedEventId()
    {
      return _lastProcessedEventId;
    }

    public void SetLastProcessedEventId(int id)
    {
      _lastProcessedEventId = id;
    }
  }
}