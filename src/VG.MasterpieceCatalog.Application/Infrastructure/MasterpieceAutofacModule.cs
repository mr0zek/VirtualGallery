using Autofac;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Infrastructure;

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
      builder.RegisterType<MasterpieceFactory>().AsImplementedInterfaces();
    }
  }
}