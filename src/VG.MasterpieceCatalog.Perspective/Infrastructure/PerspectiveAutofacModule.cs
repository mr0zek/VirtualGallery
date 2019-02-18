using Autofac;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public class PerspectiveAutofacModule : Module
  {
    private readonly string _connectionString;

    public PerspectiveAutofacModule(string connectionString)
    {
      _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<MasterpiecePerspectiveRepository>()
        .WithParameter("connectionString", _connectionString)
        .As<IMasterpiecePerspectiveRepository>();
    }
  }
}
