using System;
using System.Linq;
using Autofac;
using Autofac.Core;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public static class ContainerExtensions
  {

    public static bool HasRegistration(this IContainer container, Type serviceType)
    {
      return container.ComponentRegistry.Registrations
        .SelectMany(r => r.Services.OfType<IServiceWithType>(),
          (r, s) => new { r.Activator.LimitType, s.ServiceType }).Any();
    }

  }
}