using System;

namespace VG.MasterpieceCatalog.Infrastructure
{
  internal class ConcurrencyException : Exception
  {
    public int CurrentVersion { get; }
    public int ExpectedVersion { get; }

    public ConcurrencyException(int currentVersion, int expectedVersion)
    {
      CurrentVersion = currentVersion;
      ExpectedVersion = expectedVersion;
    }
  }
}