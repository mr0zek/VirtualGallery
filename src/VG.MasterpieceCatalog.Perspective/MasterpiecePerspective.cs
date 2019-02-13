using System;
using System.Collections.Generic;
using VG.MasterpieceCatalog.Controllers;

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
      throw new NotImplementedException();
    }
  }
}