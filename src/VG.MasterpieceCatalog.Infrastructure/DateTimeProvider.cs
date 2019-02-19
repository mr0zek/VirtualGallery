using System;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public class DateTimeProvider : IDateTimeProvider
  {
    public DateTime Now()
    {
      return DateTime.Now;
    }
  }
}