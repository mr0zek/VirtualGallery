using System.Threading.Tasks;
using RestEase;

namespace VG.MasterpieceCatalog.Contract
{
  public interface IMasterpieceEventsApi
  {
    [Get("api/events")]
    Task<Event[]> GetEventsAsync([Query]int? lastEventId, [Query]int? count);
  }
}