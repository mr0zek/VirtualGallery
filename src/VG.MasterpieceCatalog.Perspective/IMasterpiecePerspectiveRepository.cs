using System;
using System.Threading.Tasks;
using VG.MasterpieceCatalog.Contract;

namespace VG.MasterpieceCatalog.Perspective
{
  public interface IMasterpiecePerspectiveRepository
  {
    Task<MasterpiecesModel> GetManyAsync();
    Task<MasterpieceModel> GetAsync(string id);
  }
}