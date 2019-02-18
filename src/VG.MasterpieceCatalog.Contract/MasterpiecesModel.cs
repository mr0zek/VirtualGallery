using System.Collections.Generic;
using System.Linq;

namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpiecesModel
  {
    public MasterpiecesModel(IEnumerable<MasterpieceModel> masterpieces)
    {
      Masterpieces = masterpieces.ToArray();
    }

    public MasterpieceModel[] Masterpieces { get; set; }
  }
}