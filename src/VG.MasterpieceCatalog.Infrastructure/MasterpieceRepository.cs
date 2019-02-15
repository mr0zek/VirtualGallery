using System;
using System.Linq;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class CustomerRepository : ICustomerRepository
  {
    public Customer Get(CustomerId custormerId)
    {
      return new Customer(true);
    }
  }

  class MasterpieceRepository : IMasterpieceRepository
  {
    private IEventStore _eventStore;

    public MasterpieceRepository(IEventStore eventStore)
    {
      _eventStore = eventStore;
    }

    public Masterpiece Get(MasterpieceId id)
    {
      var events = _eventStore.Load(id);
      if (!events.Any())
      {
        throw new IndexOutOfRangeException();
      }

      Masterpiece m = new Masterpiece(events);
      if (m.IsRemoved())
      {
        throw new IndexOutOfRangeException(id);
      }
      return m;
    }

    public void Save(Masterpiece masterpiece, int? expectedVersion)
    {
      if (_eventStore.HasEvents(masterpiece.Id))
      {
        throw new InvalidOperationException($"Object already exists : {masterpiece.Id}");
      }
      var events = (masterpiece as IEventsCollectionAccesor).GetUncommittedChanges();
      _eventStore.Save(masterpiece.Id, events, expectedVersion);
    }

    public void Delete(Masterpiece masterpiece)
    {
      var events = (masterpiece as IEventsCollectionAccesor).GetUncommittedChanges();
      _eventStore.Save(masterpiece.Id, events, masterpiece.Version);
    }
  }
}
