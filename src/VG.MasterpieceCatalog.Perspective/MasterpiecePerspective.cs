using System;
using System.Collections.Generic;

namespace VG.MasterpieceCatalog.Perspective
{
  class MasterpiecePerspective : IMasterpiecePerspective
  {
    public IEnumerable<MasterpieceGetModel> GetMany(int count)
    {
      return new MasterpieceGetModel[]{ new MasterpieceGetModel() };
    }

    public MasterpieceGetModel Get(Guid id)
    {
      return new MasterpieceGetModel();
    }
  }
}