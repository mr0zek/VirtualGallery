using System.Threading.Tasks;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public interface IEventSubscriber
  {
    Task<int> ProcessEvents(int eventsCount);
  }
}