using System;
using System.Threading.Tasks;
using VG.MasterpieceCatalog.Contract;

namespace VG.MasterpieceCatalog.Perspective
{
  public interface IMasterpiecePerspectiveRepository
  {
    void Add(MasterpieceModel model);
    void Save(MasterpieceModel model);
    Task<MasterpiecesModel> GetManyAsync();
    Task<MasterpieceModel> GetAsync(string id);
  }
}