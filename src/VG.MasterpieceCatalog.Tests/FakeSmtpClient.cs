using VG.MasterpieceCatalog.Components.Notification.ExternalInterfaces;

namespace VG.MasterpieceCatalog.Tests
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