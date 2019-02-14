using System;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class MasterpieceRepository : IMasterpieceRepository
  {
    private IEventStore _eventStore;

    public MasterpieceRepository(IEventStore eventStore)
    {
      _eventStore = eventStore;
    }

    public Masterpiece Get(MasterpieceId id)
    {
      return new Masterpiece(_eventStore.Load(id));
    }

    public void Save(Masterpiece masterpiece)
    {
      var events = (masterpiece as IEventsCollectionAccesor).GetUncommittedChanges();
      _eventStore.Save(masterpiece.Id, events);
    }

    public void Delete(Masterpiece masterpiece)
    {
      throw new NotImplementedException();
    }
  }
}
