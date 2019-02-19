using System.Collections.Concurrent;
using Autofac;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Perspective.Infrastructure;
using Event = VG.MasterpieceCatalog.Contract.Event;

namespace VG.MasterpieceCatalog.Application.Infrastructure
{
  public class MasterpieceAutofacModule : Module
  {
    private readonly string _connectionString;
    private readonly ConcurrentQueue<Event> _queue;

    public MasterpieceAutofacModule(string connectionString, ConcurrentQueue<Event> queue)
    {
      _connectionString = connectionString;
      _queue = queue;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterModule(new InfrastructureAutofacModule(_connectionString, _queue));
      builder.RegisterType<MasterpieceFactory>().AsImplementedInterfaces();
    }
  }
}