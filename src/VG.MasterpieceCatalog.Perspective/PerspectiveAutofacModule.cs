using System;
using System.Text;
using Autofac;

namespace VG.MasterpieceCatalog.Perspective
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
      builder.RegisterType<MasterpiecePerspective>().As<IMasterpiecePerspective>();
    }
  }
}
