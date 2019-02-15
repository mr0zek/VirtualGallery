using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class Masterpiece : AggregateRootES
  {
    public MasterpieceId Id { get; }
    public string Name { get; }
    public Money Price { get; }
    private readonly string _name;
    private readonly Money _price;
    
    /// <summary>
    /// customers who bought the masterpiece
    /// </summary>
    private readonly ISet<CustomerId> _customersIds = new HashSet<CustomerId>();

    private CustomerId _reservationCustomerId;
    
    //public Masterpiece(MasterpieceId id, string name, Money price) : base(id)
    //{
    //  _name = name;
    //  _price = price;
    //}

    public Masterpiece()
    {
    }

    public Masterpiece(IEnumerable<IEvent> history)
    {
      LoadsFromHistory(history);
    }

    public Masterpiece(MasterpieceId id, string name, Money price)
    {
      Id = id;
      Name = name;
      Price = price;
      PublishEvent(new MasterpieceCreatedEvent() { AggregateId = Id, Name = Name, Price = Price, Version = Version });
    }

    public void Buy(CustomerId customerId)
    {
      if (_reservationCustomerId != customerId)
      {
        throw new DomainEvent("Can be bought");
      }

      if (_customersIds.Contains(customerId))
      {
        throw new DomainEvent("Already bought");
      }

      _customersIds.Add(customerId);

      PublishEvent(new MasterpieceBoughtEvent(Id, customerId, Version));
    }

    public void Reserve(CustomerId customerId, ICustomerRepository customerRepository)
    {
      if (!customerRepository.Get(customerId).CanReserve())
      {
        throw new DomainEvent("Only VIP Clients can reserve masterpieces");
      }

      if (_reservationCustomerId == customerId)
      {
        throw new DomainEvent("Already reserved by you");
      }

      if (_reservationCustomerId != null && _reservationCustomerId != customerId)
      {
        throw new DomainEvent("Already reserved");
      }

      _reservationCustomerId = customerId;
      PublishEvent(new MasterpieceReservedEvent(Id, customerId, Version));
    }

    public void RevokeReservation(CustomerId customerId)
    {
      if (_reservationCustomerId == null)
      {
        throw new DomainEvent("Not reserved");
      }

      if (_reservationCustomerId != null && _reservationCustomerId != customerId)
      {
        throw new DomainEvent("Not reserved by you");
      }

      _reservationCustomerId = null;
      PublishEvent(new RevokedMasterpieceReservationEvent(Id, customerId, Version));
    }
  }
}