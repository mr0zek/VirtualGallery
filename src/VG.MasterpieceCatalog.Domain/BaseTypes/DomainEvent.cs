using System;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public class DomainEvent : Exception
  {
    public DomainEvent(string message) : base(message)
    {
    }
  }
}