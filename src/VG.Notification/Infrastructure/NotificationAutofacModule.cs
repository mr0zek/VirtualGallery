using Autofac;
using VG.Notification.Features.MasterpieceReservationNotification;

namespace VG.Notification.Infrastructure
{
  public class NotificationAutofacModule : Module
  {
    private string _masterpieceCatalogUrl;

    public NotificationAutofacModule(string masterpieceCatalogUrl)
    {
      _masterpieceCatalogUrl = masterpieceCatalogUrl;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventListener<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterType<EventSubscriber>()
        .WithParameter("masterpieceCatalogUrl", _masterpieceCatalogUrl)
        .AsImplementedInterfaces();
      builder.RegisterSelf();
      builder.RegisterType<ProcessedEventsRepository>().AsImplementedInterfaces();
    }
  }
}