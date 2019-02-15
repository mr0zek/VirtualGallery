using Autofac;

namespace VG.Notification.Infrastructure
{
  public static class ContainerBuilderExtensions
  {
    public static void RegisterSelf(this ContainerBuilder builder)
    {
      IContainer container = null;
      builder.Register(c => container).AsSelf();
      builder.RegisterBuildCallback(c => container = c);
    }

  }
}
