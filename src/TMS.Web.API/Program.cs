using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TMS.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                   .AddCommandLine(args)
                   .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                   .Build();

            var builder = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>();

            var host = builder.Build();

            host.Run();
        }
    }
}
