using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace VG.MasterpieceCatalog.Perspective
{
  public class PerspectiveModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<MasterpiecePerspective>().As<IMasterpiecePerspective>();
    }
  }
}
