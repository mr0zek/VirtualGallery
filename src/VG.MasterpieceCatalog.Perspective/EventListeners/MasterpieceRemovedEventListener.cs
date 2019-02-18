using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Perspective.Infrastructure;

namespace VG.MasterpieceCatalog.Perspective.EventListeners
{
  class MasterpieceRemovedEventListener : IEventListener<MasterpieceRemovedEvent>
  {
    private readonly IMasterpiecePerspectiveRepository _masterpiecePerspectiveRepository;

    public MasterpieceRemovedEventListener(IMasterpiecePerspectiveRepository masterpiecePerspectiveRepository)
    {
      _masterpiecePerspectiveRepository = masterpiecePerspectiveRepository;
    }

    public void Handle(MasterpieceRemovedEvent obj)
    {
      Task<MasterpieceModel> model = _masterpiecePerspectiveRepository.GetAsync(obj.AggregateId);
      model.Wait();
      model.Result.IsAvailable = false;
      _masterpiecePerspectiveRepository.Save(model.Result);
    }
  }
}
