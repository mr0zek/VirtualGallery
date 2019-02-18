using System.Threading.Tasks;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Perspective.Infrastructure;

namespace VG.MasterpieceCatalog.Perspective.EventListeners
{
  class MasterpieceBoughtEventListener : IEventListener<MasterpieceBoughtEvent>
  {
    private readonly IMasterpiecePerspectiveRepository _masterpiecePerspectiveRepository;

    public MasterpieceBoughtEventListener(IMasterpiecePerspectiveRepository masterpiecePerspectiveRepository)
    {
      _masterpiecePerspectiveRepository = masterpiecePerspectiveRepository;
    }

    public void Handle(MasterpieceBoughtEvent obj)
    {
      Task<MasterpieceModel> model = _masterpiecePerspectiveRepository.GetAsync(obj.AggregateId);
      model.Wait();
      model.Result.IsAvailable = false;
      _masterpiecePerspectiveRepository.Save(model.Result);
    }
  }
}