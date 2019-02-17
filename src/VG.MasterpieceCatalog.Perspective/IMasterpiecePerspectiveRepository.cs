using System;
using System.Collections.Generic;

namespace VG.MasterpieceCatalog.Perspective
{
  public interface IMasterpiecePerspectiveRepository
  {
    void Add(MasterpieceModel model);
    void Save(MasterpieceModel model);
    IEnumerable<MasterpieceModel> GetMany();
    MasterpieceModel Get(string id);
  }
}