using System;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public class DomainException : Exception
  {
    public DomainException(string message) : base(message)
    {
    }
  }
}