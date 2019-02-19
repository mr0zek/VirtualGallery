using System.Threading.Tasks;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public interface IProcessedEventsRepository
  {
    Task<int> GetLastProcessedEventIdAsync();
    Task SetLastProcessedEventIdAsync(int id);
  }
}