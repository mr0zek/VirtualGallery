using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class Masterpiece : AggregateRootES
  {
    private readonly IDateTimeProvider _dateTimeProvider;
    private string _name;
    private Money _price;
    private DateTime _produced;

    /// <summary>
    /// customers who bought the masterpiece
    /// </summary>
    private readonly ISet<CustomerId> _customersIds = new HashSet<CustomerId>();
    private CustomerId _reservationCustomerId;
    private bool _isRemoved;

    private void Apply(MasterpieceCreatedEvent @event)
    {
      Id = @event.AggregateId;
      _name = @event.Name;
      _price = @event.Price;
      _produced = @event.Produced;
    }

    private void Apply(MasterpieceRemovedEvent @event)
    {
      _isRemoved = true;      
    }

    private void Apply(MasterpieceReservedEvent @event)
    {
      _reservationCustomerId = @event.CustomerId;      
    }

    private void Apply(RevokedMasterpieceReservationEvent @event)
    {
      _reservationCustomerId = null;      
    }

    internal Masterpiece(MasterpieceId id, string name, Money price, DateTime produced, IDateTimeProvider dateTimeProvider)
    {
      Id = id;
      _name = name;
      _price = price;
      _produced = produced;
      _dateTimeProvider = dateTimeProvider;
      PublishEvent(new MasterpieceCreatedEvent(Id, name, produced, price));
    }

    public Masterpiece(IEnumerable<IEvent> events, IDateTimeProvider dateTimeProvider)
    {
      _dateTimeProvider = dateTimeProvider;
      LoadsFromHistory(events);
    }

    public void Buy(CustomerId customerId)
    {
      if (_produced.AddYears(100) < _dateTimeProvider.Now())
      {
        throw new DomainException("Can't be bought, too young to sell");
      }
      if (_reservationCustomerId != null && _reservationCustomerId != customerId)
      {
        throw new DomainException("Can't be bought, already reserved by different user");
      }

      if (_customersIds.Contains(customerId))
      {
        throw new DomainException("Already bought");
      }

      _customersIds.Add(customerId);

      PublishEvent(new MasterpieceBoughtEvent(Id, customerId));
    }

    public void Remove()
    {
      _isRemoved = true;
      PublishEvent(new MasterpieceRemovedEvent(Id));
    }

    public void Reserve(CustomerId customerId, ICustomerRepository customerRepository)
    {
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

    public bool IsRemoved()
    {
      return _isRemoved;
    }
  }
}