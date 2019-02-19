using System;
using System.Collections.Generic;
using Rebus.Bus;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class MasterpieceRepositoryEventsDecorator : IMasterpieceRepository
  {
    private readonly IMasterpieceRepository _masterpieceRepository;
    private IEventsPublisher _eventsPublisher;

    public MasterpieceRepositoryEventsDecorator(IMasterpieceRepository masterpieceRepository, IEventsPublisher eventsPublisher)
    {
      _masterpieceRepository = masterpieceRepository;
      _eventsPublisher = eventsPublisher;
    }
    public Masterpiece Get(MasterpieceId id)
    {
      return _masterpieceRepository.Get(id);
    }

    public void Save(Masterpiece masterpiece)
    {
      _masterpieceRepository.Save(masterpiece);
      _eventsPublisher.Publish((masterpiece as IEventsAccesor).GetEvents());
    }
  }

  internal interface IEventsPublisher
  {
    void Publish(IEnumerable<IEvent> events);
  }

  class EventsPublisher : IEventsPublisher
  {
    private readonly IBus _bus;
    private IEventsConverter _converter;

    public EventsPublisher(Rebus.Bus.IBus bus, IEventsConverter converter)
    {
      _bus = bus;
      _converter = converter;
    }

    public void Publish(IEnumerable<IEvent> events)
    {
      foreach (var @event in events)
      {
        _bus.Publish(_converter.Convert(@event));
      }
    }
  }

  internal interface IEventsConverter
  {
    object Convert(IEvent @event);
  }

  class EventsConverter : IEventsConverter
  {
    public object Convert(IEvent @event)
    {
      if(@event.GetType() == typeof(Domain.MasterpieceCreatedEvent))
      { 
        return new Contract.MasterpieceCreatedEvent()
        {
          Version = ()@event
        }
      }
    }
  }
}