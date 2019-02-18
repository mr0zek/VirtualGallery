using System.Threading.Tasks;
using RestEase;

namespace VG.MasterpieceCatalog.Contract
{
  public interface IMasterpieceEventsApi
  {
    [Get("api/events")]
    Task<MasterpieceEvents> GetEventsAsync([Query]int? lastEventId, [Query]int? count);
  }
}