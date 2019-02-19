using System.Runtime.Serialization;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class EventsConverter : IEventsConverter
  {
    public Event Convert(IEvent @event)
    {
      var eventType = @event.GetType();
      if (eventType == typeof(Domain.MasterpieceBoughtEvent))
      {
        return new MasterpieceBoughtEvent()
        {
          AggregateId = @event.AggregateId,
          CustomerId = ((Domain.MasterpieceBoughtEvent)@event).CustomerId
        };
      }
      if (eventType == typeof(Domain.MasterpieceCreatedEvent))
      {
        return new MasterpieceCreatedEvent()
        {
          AggregateId = @event.AggregateId,
          Name = ((Domain.MasterpieceCreatedEvent)@event).Name,
          Price = ((Domain.MasterpieceCreatedEvent)@event).Price
        };
      }
      if (eventType == typeof(Domain.MasterpieceReservedEvent))
      {
        return new MasterpieceReservedEvent()
        {
          AggregateId = @event.AggregateId,
          CustomerId = ((Domain.MasterpieceReservedEvent)@event).CustomerId,
        };
      }
      if (eventType == typeof(Domain.RevokedMasterpieceReservationEvent))
      {
        return new RevokedMasterpieceReservationEvent()
        {
          AggregateId = @event.AggregateId,
          CustomerId = ((Domain.RevokedMasterpieceReservationEvent)@event).CustomerId,
        };
      }
      if (eventType == typeof(MasterpieceRemovedEvent))
      {
        return new MasterpieceRemovedEvent()
        {
        };
      }

      throw new SerializationException("Not supported type : " + eventType.Name);
    }
  }

}