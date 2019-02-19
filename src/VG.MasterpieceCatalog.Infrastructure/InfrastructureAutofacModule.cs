using System.Collections.Concurrent;
using Autofac;
using VG.MasterpieceCatalog.Contract;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public class InfrastructureAutofacModule : Module
  {
    private readonly string _connectionString;
    private readonly ConcurrentQueue<Event> _queue;

    public InfrastructureAutofacModule(string connectionString, ConcurrentQueue<Event> queue)
    {
      _connectionString = connectionString;
      _queue = queue;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(context => new MasterpieceRepositoryEventsDecorator(
            new MasterpieceRepository(context.Resolve<IDateTimeProvider>(), _connectionString), context.Resolve<IEventsPublisher>()))
        .AsImplementedInterfaces();

      builder.RegisterType<CustomerRepository>().AsImplementedInterfaces();
      builder.RegisterType<DateTimeProvider>().AsImplementedInterfaces();
      builder.RegisterType<EventsConverter>().AsImplementedInterfaces();
      builder.RegisterType<EventsPublisher>()
        .WithParameter("queue",_queue).AsImplementedInterfaces();
    }
  }
}