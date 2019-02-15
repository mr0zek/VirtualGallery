using Autofac;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Perspective;

namespace VG.MasterpieceCatalog.Application.Infrastructure
{
  public class MasterpieceAutofacModule : Module
  {
    private string _connectionString;

    public MasterpieceAutofacModule(string connectionString)
    {
      _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterModule(new InfrastructureAutofacModule(_connectionString));
      builder.RegisterModule(new PerspectiveAutofacModule(_connectionString));
    }
  }
}