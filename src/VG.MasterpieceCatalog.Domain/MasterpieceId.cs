using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceId : ValueObject
  {
    private readonly Guid _id;

    private MasterpieceId(Guid id)
    {
      _id = id;
    }

    public static implicit operator MasterpieceId(Guid id)
    {
      return new MasterpieceId(id);
    }

    public static implicit operator Guid(MasterpieceId id)
    {
      return id._id;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return _id;
    }
  }
}