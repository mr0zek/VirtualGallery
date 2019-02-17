using Autofac;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public class PerspectiveAutofacModule : Module
  {
    private readonly string _connectionString;
    private string _masterpieceCatalogUrl;

    public PerspectiveAutofacModule(string connectionString, string masterpieceCatalogUrl)
    {
      _connectionString = connectionString;
      _masterpieceCatalogUrl = masterpieceCatalogUrl;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterSelf();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventListener<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterType<EventSubscriber>()
        .WithParameter("masterpieceCatalogUrl", _masterpieceCatalogUrl)
        .AsImplementedInterfaces();

      builder.RegisterType<MasterpiecePerspectiveRepository>()
        .WithParameter("connectionString", _connectionString)
        .As<IMasterpiecePerspectiveRepository>();
    }
  }
}
