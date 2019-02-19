using System.Collections.Concurrent;
using Autofac;
using VG.MasterpieceCatalog.Contract;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public class PerspectiveAutofacModule : Module
  {
    private readonly string _connectionString;
    private readonly ConcurrentQueue<Event> _eventsQueue;

    public PerspectiveAutofacModule(string connectionString, ConcurrentQueue<Event> eventsQueue)
    {
      _connectionString = connectionString;
      _eventsQueue = eventsQueue;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterSelf();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventListener<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterType<EventSubscriber>()
        .WithParameter("queue", _eventsQueue)
        .AsImplementedInterfaces();

      builder.RegisterType<MasterpiecePerspectiveRepository>()
        .WithParameter("connectionString", _connectionString)
        .As<IMasterpiecePerspectiveRepository>();
    }
  }
}
