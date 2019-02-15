﻿using VG.Notification.ExternalInterfaces;
using VG.Notification.Infrastructure;

namespace VG.Notification.Features.MasterpieceReservationNotification
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