namespace VG.Notification.ExternalInterfaces
{
  public interface ISmtpClient
  {
    void Send(object template, object data);
  }
}