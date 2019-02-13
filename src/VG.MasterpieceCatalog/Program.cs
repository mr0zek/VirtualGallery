using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace VG.MasterpieceCatalog
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
          .UseKestrel(f => f.ListenAnyIP(12121))
          .UseStartup<Startup>();
  }
}
