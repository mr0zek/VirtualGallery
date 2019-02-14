using System;
using System.Text;
using Autofac;

namespace VG.MasterpieceCatalog.Perspective
{
  public class PerspectiveAutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<MasterpiecePerspective>().As<IMasterpiecePerspective>();
    }
  }
}
