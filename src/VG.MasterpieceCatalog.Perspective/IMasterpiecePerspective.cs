using System;
using System.Collections.Generic;

namespace VG.MasterpieceCatalog.Perspective
{
  public interface IMasterpiecePerspective
  {
    IEnumerable<MasterpieceGetModel> GetMany(int count);
    MasterpieceGetModel Get(Guid id);
  }
}