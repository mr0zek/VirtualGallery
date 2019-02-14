using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Perspective;

namespace VG.MasterpieceCatalog.Components.Notification
{
  public class NetificationStartup
  {
    private static readonly List<Module> _autofacModulesToRegister = new List<Module>();

    public static void RegisterAutofacModule(IEnumerable<Module> modules)
    {
      foreach (Module module in modules)
      {
        _autofacModulesToRegister.Add(module);
      }
    }

    public NetificationStartup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddMvc();

      services.AddLogging(loggingBuilder =>
      {
        loggingBuilder
          .AddConsole()
          .AddConfiguration(Configuration.GetSection("logging"))
          .AddDebug();
      });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "Masterpiece API", Version = "v1" });
      });

      var builder = new ContainerBuilder();
      builder.RegisterModule<NotificationAutofacModule>();
      foreach (var module in _autofacModulesToRegister)
      {
        builder.RegisterModule(module);
      }
      builder.Populate(services);
      var container = builder.Build();
      return new AutofacServiceProvider(container);
    }



    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHangfireServer();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });

      //app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
