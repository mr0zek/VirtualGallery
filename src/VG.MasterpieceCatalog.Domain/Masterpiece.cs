using System.Collections.Generic;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class Masterpiece : AggregateRoot
  {
    /// <summary>
    /// customers who bought the masterpiece
    /// </summary>
    private readonly ISet<CustomerId> _customersIds = new HashSet<CustomerId>();

    private CustomerId _reservationCustomerId;

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