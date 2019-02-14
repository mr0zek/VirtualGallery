using Autofac;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public class InfrastructureAutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<MasterpieceRepository>().AsImplementedInterfaces();
      builder.RegisterType<EventStore>().AsImplementedInterfaces();
    }
  }
}