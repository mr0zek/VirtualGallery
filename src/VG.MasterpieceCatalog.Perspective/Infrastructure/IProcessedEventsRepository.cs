using System.Threading.Tasks;

namespace VG.MasterpieceCatalog.Perspective
{
  public interface IProcessedEventsRepository
  {
    Task<int> GetLastProcessedEventIdAsync();
    Task SetLastProcessedEventIdAsync(int id);
  }
}