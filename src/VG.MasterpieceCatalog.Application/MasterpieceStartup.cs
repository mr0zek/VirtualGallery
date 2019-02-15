﻿using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Infrastructure;
using VG.MasterpieceCatalog.Perspective;
using FluentValidation.AspNetCore;

namespace VG.MasterpieceCatalog.Application
{
  public class MasterpieceStartup
  {
    public MasterpieceStartup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public static Action<ContainerBuilder> RegisterExternalTypes { get; set; }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services
        .AddMvc(opt => opt.Filters.Add(typeof(FluentValidationActionFilter)))
        .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<MasterpieceStartup>());

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
      string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
      builder.RegisterModule(new MasterpieceAutofacModule(connectionString));
      RegisterExternalTypes(builder);
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
