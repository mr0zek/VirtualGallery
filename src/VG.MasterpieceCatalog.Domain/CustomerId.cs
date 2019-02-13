using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class CustomerId : ValueObject
  {
    private string _id;

    public CustomerId(string id)
    {
      _id = id;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return _id;
    }

    public static implicit operator CustomerId(Guid id)
    {
      return new CustomerId(id.ToString());
    }

    public static implicit operator CustomerId(string id)
    {
      return new CustomerId(id);
    }

    public static implicit operator string(CustomerId id)
    {
      return id._id;
    }
  }
}
