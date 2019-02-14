using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestEase;
using VG.MasterpieceCatalog.Components.MasterpiecePerspective.Contract;

namespace VG.MasterpieceCatalog.Components.Notification.ExternalInterfaces
{
    interface IMasterpieceEventsApi
    {
      [Get("api/events/{userId}")]
      Task<MasterpiecePerspectiveResponse> GetUserAsync([Path] string userId);
  }
}
