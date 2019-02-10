using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace VG.MasterpieceCatalog.Controllers
{
  public interface IMasterpiecePerspective
  {
    IEnumerable<MasterpieceGetModel> GetMany(int count);
    MasterpieceGetModel Get(Guid id);
  }
}