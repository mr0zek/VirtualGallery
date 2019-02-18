using System;
using VG.MasterpieceCatalog.Contract;

namespace VG.MasterpieceCatalog.Perspective
{
  public interface IMasterpiecePerspectiveRepository
  {
    void Add(MasterpieceModel model);
    void Save(MasterpieceModel model);
    MasterpiecesModel GetMany();
    MasterpieceModel Get(string id);
  }
}