using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceId : ValueObject
  {
    private readonly string _id;

    private MasterpieceId(string id)
    {
      _id = id;
    }

    public static implicit operator MasterpieceId(Guid id)
    {
      return new MasterpieceId(id.ToString());
    }

    public static implicit operator MasterpieceId(string id)
    {
      return new MasterpieceId(id);
    }

    public static implicit operator string(MasterpieceId id)
    {
      return id._id;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return _id;
    }
  }
}