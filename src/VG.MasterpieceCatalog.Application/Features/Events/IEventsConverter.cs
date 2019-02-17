using System.Runtime.Serialization;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Features.Events
{
  internal interface IEventsConverter
  {
    Contract.Event Convert(Event @event);
  }

  class EventsConverter : IEventsConverter
  {
    public Contract.Event Convert(Event @event)
    {
      var eventType = @event.Data.GetType();
      if (eventType == typeof(MasterpieceBoughtEvent))
      {
        return new Contract.MasterpieceBoughtEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id,
          Type = @event.Data.GetType().Name,
          CustomerId = (@event.Data as MasterpieceBoughtEvent).CustomerId
        };
      }
      if (eventType == typeof(MasterpieceCreatedEvent))
      {
        return new Contract.MasterpieceCreatedEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id,
          Type = @event.Data.GetType().Name,
          Name = (@event.Data as MasterpieceCreatedEvent).Name,
          Price = (@event.Data as MasterpieceCreatedEvent).Price
        };
      }
      if (eventType == typeof(MasterpieceReservedEvent))
      {
        return new Contract.MasterpieceReservedEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id,
          Type = @event.Data.GetType().Name,
          CustomerId = (@event.Data as MasterpieceReservedEvent).CustomerId,
        };
      }
      if (eventType == typeof(RevokedMasterpieceReservationEvent))
      {
        return new Contract.MasterpieceReservedEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id,
          Type = @event.Data.GetType().Name,
          CustomerId = (@event.Data as RevokedMasterpieceReservationEvent).CustomerId,
        };
      }
      if (eventType == typeof(MasterpieceRemovedEvent))
      {
        return new Contract.MasterpieceRemovedEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id,
          Type = @event.Data.GetType().Name,
        };
      }

      throw new SerializationException("not trcognized type : "+eventType.Name);
    }
  }
}