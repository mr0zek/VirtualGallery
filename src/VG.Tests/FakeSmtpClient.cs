using VG.Notification.ExternalInterfaces;

namespace VG.Tests
{
  public class FakeSmtpClient : ISmtpClient
  {
    public static int Count;
    public void Send(object template, object data)
    {
      Count++;
    }
  }
}