using Autofac;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Perspective.Infrastructure;

namespace VG.MasterpieceCatalog.Application.Infrastructure
{
  public class MasterpieceAutofacModule : Module
  {
    private readonly string _connectionString;
    private readonly string _eventsUrl;

    public MasterpieceAutofacModule(string connectionString, string eventsUrl)
    {
      _connectionString = connectionString;
      _eventsUrl = eventsUrl;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterModule(new InfrastructureAutofacModule(_connectionString));
      builder.RegisterModule(new PerspectiveAutofacModule(_connectionString, _eventsUrl));
      builder.RegisterType<MasterpieceFactory>().AsImplementedInterfaces();
    }
  }
}