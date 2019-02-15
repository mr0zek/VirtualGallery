namespace VG.Notification.Infrastructure
{
  public interface IEventListener<T>
  {
    void Handle(T obj);
  }
}