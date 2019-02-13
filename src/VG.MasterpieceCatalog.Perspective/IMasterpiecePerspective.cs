using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Controllers;

namespace VG.MasterpieceCatalog.Perspective
{
  public interface IMasterpiecePerspective
  {
    IEnumerable<MasterpieceGetModel> GetMany(int count);
    MasterpieceGetModel Get(Guid id);
  }
}