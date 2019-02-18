using System.Runtime.Serialization;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Features.Events
{
  public interface IEventsConverter
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
          CustomerId = ((MasterpieceBoughtEvent) @event.Data).CustomerId
        };
      }
      if (eventType == typeof(MasterpieceCreatedEvent))
      {
        return new Contract.MasterpieceCreatedEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id,
          Name = ((MasterpieceCreatedEvent) @event.Data).Name,
          Price = ((MasterpieceCreatedEvent) @event.Data).Price
        };
      }
      if (eventType == typeof(MasterpieceReservedEvent))
      {
        return new Contract.MasterpieceReservedEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id,
          CustomerId = ((MasterpieceReservedEvent) @event.Data).CustomerId,
        };
      }
      if (eventType == typeof(RevokedMasterpieceReservationEvent))
      {
        return new Contract.RevokedMasterpieceReservationEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id,
          CustomerId = ((RevokedMasterpieceReservationEvent) @event.Data).CustomerId,
        };
      }
      if (eventType == typeof(MasterpieceRemovedEvent))
      {
        return new Contract.MasterpieceRemovedEvent()
        {
          AggregateId = @event.Data.AggregateId,
          Version = @event.Version,
          Id = @event.Id
        };
      }

      throw new SerializationException("Not supported type : "+eventType.Name);
    }
  }
}