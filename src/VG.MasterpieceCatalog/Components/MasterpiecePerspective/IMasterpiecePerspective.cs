using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Components.MasterpiecePerspective.Contract;

namespace VG.MasterpieceCatalog.Components.MasterpiecePerspective
{
  public interface IMasterpiecePerspective
  {
    IEnumerable<MasterpiecePerspectiveResponse> GetMany(int count);
    MasterpiecePerspectiveResponse Get(Guid id);
  }
}