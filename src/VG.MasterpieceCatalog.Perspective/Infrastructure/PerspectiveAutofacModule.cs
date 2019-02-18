using Autofac;
using VG.Notification.Infrastructure;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public class PerspectiveAutofacModule : Module
  {
    private readonly string _connectionString;
    private string _eventsUrl;

    public PerspectiveAutofacModule(string connectionString, string eventsUrl)
    {
      _connectionString = connectionString;
      _eventsUrl = eventsUrl;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterSelf();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventListener<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterType<EventSubscriber>()
        .WithParameter("eventsUrl", _eventsUrl)
        .AsImplementedInterfaces();

      builder.RegisterType<ProcessedEventsRepository>()
        .WithParameter("connectionString", _connectionString)
        .AsImplementedInterfaces();

      builder.RegisterType<MasterpiecePerspectiveRepository>()
        .WithParameter("connectionString", _connectionString)
        .As<IMasterpiecePerspectiveRepository>();
    }
  }
}
