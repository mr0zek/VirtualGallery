namespace VG.Notification.Features.MasterpieceReservationNotification
{
  public interface IEventListener<T>
  {
    void Handle(T obj);
  }
}