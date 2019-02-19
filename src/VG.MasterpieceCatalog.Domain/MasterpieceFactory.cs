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
      return new Masterpiece(
        new MasterpieceState(id, name, price, produced, 0, false),
        _dateTimeProvider);
    }
  }
}