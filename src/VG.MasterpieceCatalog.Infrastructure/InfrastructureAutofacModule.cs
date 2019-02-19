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
      builder.RegisterType<MasterpieceRepository>().AsImplementedInterfaces();
      builder.RegisterType<CustomerRepository>().AsImplementedInterfaces();
      builder.RegisterType<DateTimeProvider>().AsImplementedInterfaces();
    }
  }
}