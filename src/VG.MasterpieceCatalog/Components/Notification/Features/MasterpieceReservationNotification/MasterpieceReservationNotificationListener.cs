using VG.MasterpieceCatalog.BaseTypes;
using VG.MasterpieceCatalog.Components.Notification.ExternalInterfaces;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Components.Notification.MasterpieceReservationNotification
{
  public class MasterpieceReservationNotificationListener : IEventListener<MasterpieceReservedEvent>
  {
    private readonly ISmtpClient _sendMail;

    public MasterpieceReservationNotificationListener(ISmtpClient sendMail)
    {
      _sendMail = sendMail;
    }

    public void Handle(MasterpieceReservedEvent @event)
    {
      _sendMail.Send("", "");
    }
  }
}
