using Autofac;
using VG.MasterpieceCatalog.BaseTypes;

namespace VG.MasterpieceCatalog.Components.Notification
{
  public class NotificationAutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .Where(f=>f.Namespace.Contains(typeof(NotificationAutofacModule).Namespace))
        .AsClosedTypesOf(typeof(IEventListener<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}