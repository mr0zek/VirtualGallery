using System;

namespace VG.MasterpieceCatalog.Domain
{
  public interface IMasterpieceFactory
  {
    Masterpiece Create(MasterpieceId id, string name, Money price, DateTime produced);
  }
}