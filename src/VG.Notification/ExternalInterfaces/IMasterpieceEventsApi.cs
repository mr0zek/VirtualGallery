using RestEase;

namespace VG.Notification.ExternalInterfaces
{
  internal interface IMasterpieceEventsApi
  {
    [Get("api/events/{userId}")]
    MasterpieceEvent[] GetEvents([Path] int lastProcessedEventId, int count);
  }
}
