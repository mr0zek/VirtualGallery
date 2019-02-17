using System;
using System.Collections.Generic;
using System.Text;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Perspective.Infrastructure;

namespace VG.MasterpieceCatalog.Perspective.EventListeners
{
  class MasterpieceCreatedEventListener : IEventListener<MasterpieceCreatedEvent>
  {
    private readonly IMasterpiecePerspectiveRepository _masterpiecePerspectiveRepository;

    public MasterpieceCreatedEventListener(IMasterpiecePerspectiveRepository masterpiecePerspectiveRepository)
    {
      _masterpiecePerspectiveRepository = masterpiecePerspectiveRepository;
    }

    public void Handle(MasterpieceCreatedEvent obj)
    {
      _masterpiecePerspectiveRepository.Add(new MasterpieceModel(){ AggregateId = obj.AggregateId, Name = obj.Name, Price = obj.Price, Version = obj.Version });
    }
  }
}
