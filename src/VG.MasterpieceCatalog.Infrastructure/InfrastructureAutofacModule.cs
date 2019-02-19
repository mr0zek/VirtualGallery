using Autofac;

namespace VG.MasterpieceCatalog.Infrastructure
{
  public class InfrastructureAutofacModule : Module
  {
    private readonly string _connectionString;

    public InfrastructureAutofacModule(string connectionString)
    {
      _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(context => new MasterpieceRepositoryEventsDecorator(
            new MasterpieceRepository(context.Resolve<DateTimeProvider>(), _connectionString), context.Resolve<IEventsPublisher>()))
        .AsImplementedInterfaces();

      builder.RegisterType<CustomerRepository>().AsImplementedInterfaces();
      builder.RegisterType<DateTimeProvider>().AsImplementedInterfaces();
      builder.RegisterType<EventsConverter>().AsImplementedInterfaces();
      builder.RegisterType<EventsPublisher>().AsImplementedInterfaces();
      builder.RegisterType<EventsPublisher>().AsImplementedInterfaces();
    }
  }
}