using System;

namespace VG.MasterpieceCatalog.Domain
{
  public interface IDateTimeProvider
  {
    DateTime Now();
  }
}