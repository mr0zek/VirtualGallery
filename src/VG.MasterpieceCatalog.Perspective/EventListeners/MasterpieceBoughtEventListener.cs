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
      MasterpieceModel model = _masterpiecePerspectiveRepository.Get(obj.AggregateId);
      model.IsAvailable = false;
      _masterpiecePerspectiveRepository.Save(model);
    }
  }
}