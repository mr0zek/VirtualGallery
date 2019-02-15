using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace VG.MasterpieceCatalog.Application.Infrastructure
{
  public class ErrorHandlingMiddleware
  {
    private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        HandleExceptionAsync(context, ex);
      }
    }

    private static void HandleExceptionAsync(HttpContext context, Exception exception)
    {
      var code = HttpStatusCode.InternalServerError; // 500 if unexpected

      if (exception is IndexOutOfRangeException) code = HttpStatusCode.NotFound;
            
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;
      if (code == HttpStatusCode.InternalServerError)
      {
        _log.Error("Unhandled exception", exception);
      }
    }
  }
}
