using Autofac;
using VG.MasterpieceCatalog.Application.BaseTypes;

namespace VG.MasterpieceCatalog
{
  public class ApplicationModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}