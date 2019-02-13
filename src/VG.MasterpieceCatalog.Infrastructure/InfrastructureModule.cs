using Autofac;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public class InfrastructureModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<MasterpieceRepository>().AsImplementedInterfaces();
    }
  }
}