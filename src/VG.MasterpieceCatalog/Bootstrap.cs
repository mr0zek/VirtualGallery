using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Hangfire;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using VG.MasterpieceCatalog.Application;
using VG.MasterpieceCatalog.Components.Notification;

namespace VG.MasterpieceCatalog
{
  public class Bootstrap
  {
    public void Run(string[] args)
    {
      MasterpieceBootstrap.Run(args, builder => { });
      NotificationBootstrap.Run(args, builder => { });
    }
  }  
}
