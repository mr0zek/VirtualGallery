using System;
using System.Collections.Generic;
using System.Text;
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
      MasterpieceModel model = _masterpiecePerspectiveRepository.Get(obj.AggregateId);
      model.IsAvaiable = false;
      _masterpiecePerspectiveRepository.Save(model);
    }
  }
}
