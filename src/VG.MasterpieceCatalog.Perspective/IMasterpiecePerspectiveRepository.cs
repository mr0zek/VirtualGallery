using System;
using System.Collections.Generic;

namespace VG.MasterpieceCatalog.Perspective
{
  public interface IMasterpiecePerspectiveRepository
  {
    void Add(MasterpieceModel model);
    void Save(MasterpieceModel model);
    MasterpiecesModel GetMany();
    MasterpieceModel Get(string id);
  }

  public class MasterpiecesModel
  {
    public IEnumerable<MasterpieceModel> Masterpieces { get; set; }
    public MasterpiecesModel(IEnumerable<MasterpieceModel> masterpieces)
    {
      Masterpieces = masterpieces;
    }    
  }
}