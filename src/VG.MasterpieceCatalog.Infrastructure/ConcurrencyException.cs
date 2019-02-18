using System;

namespace VG.MasterpieceCatalog.Infrastructure
{
  internal class ConcurrencyException : Exception
  {
    public int ExpectedVersion { get; }

    public ConcurrencyException(int expectedVersion)
    {
      ExpectedVersion = expectedVersion;
    }
  }
}