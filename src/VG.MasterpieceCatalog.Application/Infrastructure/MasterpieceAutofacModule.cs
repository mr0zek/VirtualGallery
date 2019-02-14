using Autofac;
using VG.MasterpieceCatalog.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Infrastructure
{
  public class MasterpieceAutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .Where(f=>f.Namespace.Contains(typeof(MasterpieceAutofacModule).Namespace))
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterModule<InfrastructureAutofacModule>();
    }
  }
}