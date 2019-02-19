using System;

namespace VG.MasterpieceCatalog.Infrastructure
{
  internal class ConcurrencyException : Exception
  {
    public int CurrentVersion { get; }
    
    public ConcurrencyException(int currentVersion)
    {
      CurrentVersion = currentVersion;    
    }
  }
}