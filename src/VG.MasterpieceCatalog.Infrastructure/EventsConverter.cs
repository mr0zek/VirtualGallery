using System.Runtime.Serialization;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class EventsConverter : IEventsConverter
  {
    public object Convert(IEvent @event)
    {
      var eventType = @event.GetType();
      if (eventType == typeof(MasterpieceBoughtEvent))
      {
        return new Contract.MasterpieceBoughtEvent()
        {
          AggregateId = @event.AggregateId,
          CustomerId = ((MasterpieceBoughtEvent)@event).CustomerId
        };
      }
      if (eventType == typeof(MasterpieceCreatedEvent))
      {
        return new Contract.MasterpieceCreatedEvent()
        {
          AggregateId = @event.AggregateId,
          Name = ((MasterpieceCreatedEvent)@event).Name,
          Price = ((MasterpieceCreatedEvent)@event).Price
        };
      }
      if (eventType == typeof(MasterpieceReservedEvent))
      {
        return new Contract.MasterpieceReservedEvent()
        {
          AggregateId = @event.AggregateId,
          CustomerId = ((MasterpieceReservedEvent)@event).CustomerId,
        };
      }
      if (eventType == typeof(RevokedMasterpieceReservationEvent))
      {
        return new Contract.RevokedMasterpieceReservationEvent()
        {
          AggregateId = @event.AggregateId,
          CustomerId = ((RevokedMasterpieceReservationEvent)@event).CustomerId,
        };
      }
      if (eventType == typeof(MasterpieceRemovedEvent))
      {
        return new Contract.MasterpieceRemovedEvent()
        {
        };
      }

      throw new SerializationException("Not supported type : " + eventType.Name);
    }
  }

}