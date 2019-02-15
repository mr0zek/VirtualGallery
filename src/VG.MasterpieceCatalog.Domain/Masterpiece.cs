using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class Masterpiece : AggregateRootES
  {
    private string _name;
    private Money _price;
    /// <summary>
    /// customers who bought the masterpiece
    /// </summary>
    private readonly ISet<CustomerId> _customersIds = new HashSet<CustomerId>();
    private CustomerId _reservationCustomerId;
    private bool _isRemoved;

    public Masterpiece(IEnumerable<IEvent> history)
    {
      LoadsFromHistory(history);
    }

    private void Apply(MasterpieceCreatedEvent @event)
    {
      Id = @event.AggregateId;
      _name = @event.Name;
      _price = @event.Price;      
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

    public Masterpiece(MasterpieceId id, string name, Money price)
    {
      Id = id;
      _name = name;
      _price = price;
      PublishEvent(new MasterpieceCreatedEvent() { AggregateId = Id, Name = _name, Price = _price });
    }

    public void Buy(CustomerId customerId)
    {
      if (_reservationCustomerId != customerId)
      {
        throw new DomainException("Can be bought");
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