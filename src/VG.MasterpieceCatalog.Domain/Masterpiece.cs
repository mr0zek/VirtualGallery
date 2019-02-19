using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;
using VG.MasterpieceCatalog.Domain.BaseTypes.VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class Masterpiece : AggregateRoot
  {
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly string _name;
    private readonly Money _price;
    private readonly DateTime _produced;
    private CustomerId _customerId;
    private CustomerId _reservationCustomerId;
    private bool _isRemoved;

    public Masterpiece(MasterpieceState state, IDateTimeProvider dateTimeProvider)
    {
      Id = state.Id;
      _name = state.Name;
      _price = state.Price;
      _isRemoved = state.IsRemoved;
      Version = state.Version;
      _produced = state.Produced;
      _dateTimeProvider = dateTimeProvider;
      PublishEvent(new MasterpieceCreatedEvent(Id, _name, _produced, _price));
    }

    public void Buy(CustomerId customerId)
    {
      if (_customerId != null)
      {
        throw new DomainException("Already sold");
      }
      if (_produced.AddYears(10) < _dateTimeProvider.Now())
      {
        throw new DomainException("Can't be bought, too young to sell");
      }
      if (_reservationCustomerId != null && _reservationCustomerId != customerId)
      {
        throw new DomainException("Can't be bought, already reserved by different user");
      }

      _customerId = customerId;

      PublishEvent(new MasterpieceBoughtEvent(Id, customerId));
    }

    public void Remove()
    {
      _isRemoved = true;
      PublishEvent(new MasterpieceRemovedEvent(Id));
    }

    public void Reserve(CustomerId customerId, ICustomerRepository customerRepository)
    {
      if (_customerId != null)
      {
        throw new DomainException("Already sold");
      }
      if (!customerRepository.Get(customerId).CanReserve())
      {
        throw new DomainException("Only VIP Clients can reserve masterpieces");
      }

      if (_reservationCustomerId == customerId)
      {
        throw new DomainException("Already reserved by you");
      }

      if (_reservationCustomerId != null && _reservationCustomerId != customerId)
      {
        throw new DomainException("Already reserved");
      }

      _reservationCustomerId = customerId;
      PublishEvent(new MasterpieceReservedEvent(Id, customerId));
    }

    public void RevokeReservation(CustomerId customerId)
    {
      if (_reservationCustomerId == null)
      {
        throw new DomainException("Not reserved");
      }

      if (_reservationCustomerId != null && _reservationCustomerId != customerId)
      {
        throw new DomainException("Not reserved by you");
      }

      _reservationCustomerId = null;
      PublishEvent(new RevokedMasterpieceReservationEvent(Id, customerId));
    }

    public MasterpieceState GetState()
    {
      return new MasterpieceState(Id, _name, _price, _produced, Version, _isRemoved);
    }
  }
}