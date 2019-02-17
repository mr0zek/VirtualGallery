using System;
using System.Linq;
using Autofac;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;
using VG.MasterpieceCatalog.Infrastructure.SqlEventStore;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class MasterpieceRepository : IMasterpieceRepository
  {
    private readonly IEventStore _eventStore;
    private readonly IDateTimeProvider _dateTimeProvider;

    public MasterpieceRepository(IEventStore eventStore, IDateTimeProvider dateTimeProvider)
    {
      _eventStore = eventStore;
      _dateTimeProvider = dateTimeProvider;
    }

    public Masterpiece Get(MasterpieceId id)
    {
      var events = _eventStore.Load(id);
      if (!events.Any())
      {
        throw new IndexOutOfRangeException();
      }

      Masterpiece m = new Masterpiece(events, _dateTimeProvider);
      if (m.IsRemoved())
      {
        throw new IndexOutOfRangeException(id);
      }
      return m;
    }

    public void Save(Masterpiece masterpiece, int? expectedVersion)
    {
      var events = (masterpiece as IEventsAccesor).GetUncommittedChanges();
      if (events.First().GetType().IsAssignableFrom(typeof(MasterpieceCreatedEvent)))
      {
        if (_eventStore.HasEvents(masterpiece.Id))
        {
          throw new InvalidOperationException($"Object already exists : {masterpiece.Id}");
        }
      }
      _eventStore.Save(masterpiece.Id, events, expectedVersion);
    }
  }
}
