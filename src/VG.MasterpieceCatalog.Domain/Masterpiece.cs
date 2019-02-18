using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class Masterpiece : AggregateRoot
  {
    private readonly IDateTimeProvider _dateTimeProvider;
    private string _name;
    private Money _price;
    private DateTime _produced;

    /// <summary>
    /// customers who bought the masterpiece
    /// </summary>
    private CustomerId _customerId;
    private CustomerId _reservationCustomerId;
    private bool _isRemoved;

    public Masterpiece(MasterpieceState state, IDateTimeProvider dateTimeProvider)
    {
      Id = state.Id;
      _name = state.Name;
      _price = state.Price;
      _produced = state.Produced;
      Version = state.Version;
      _isRemoved = state.IsRemoved;
      _dateTimeProvider = dateTimeProvider;
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
    }

    public void Remove()
    {
      if (_customerId != null)
      {
        throw new DomainException("Already sold");
      } 
      _isRemoved = true;
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
    }

    public bool IsRemoved()
    {
      return _isRemoved;
    }

    public MasterpieceState GetState()
    {
      return new MasterpieceState(Id, _name, _price, _produced, Version, _isRemoved);
    }
  }
}