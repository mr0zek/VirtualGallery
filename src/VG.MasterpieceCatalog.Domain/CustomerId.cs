using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class CustomerId : ValueObject
  {
    private Guid _id;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return _id;
    }
  }
}
