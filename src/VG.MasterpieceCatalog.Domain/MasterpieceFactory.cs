using System;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceFactory : IMasterpieceFactory
  {
    private readonly IDateTimeProvider _dateTimeProvider;

    public MasterpieceFactory(IDateTimeProvider dateTimeProvider)
    {
      _dateTimeProvider = dateTimeProvider;
    }

    public Masterpiece Create(MasterpieceId id, string name, Money price, DateTime produced)
    {
      return new Masterpiece(id, name, price, produced, _dateTimeProvider);
    }
  }
}