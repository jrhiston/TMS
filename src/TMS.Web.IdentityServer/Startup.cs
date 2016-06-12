using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.Extensions.Logging;
using IdentityServer4.Core.Validation;
using IdentityServer4.Core.Services;

namespace TMS.Web.IdentityServer
{
    public class Startup
    {
        private readonly IApplicationEnvironment _environment;

        public Startup(IApplicationEnvironment environment)
        {
            _environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var cert = new X509Certificate2(Path.Combine(_environment.ApplicationBasePath, "idsrv4tms.pfx"), "idsrv4tms");

            var builder = services.AddIdentityServer(options =>
            {
                //options.SigningCertificate = cert;
            });

            builder.AddInMemoryClients(Clients.Get());
            builder.AddInMemoryScopes(Scopes.Get());
            builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            builder.Services.AddTransient<IProfileService, ProfileService>();

            builder.AddCustomGrantValidator<Extensions.CustomGrantValidator>();

            // for the UI
            services
                .AddMvc()
                .AddRazorOptions(razor =>
                {
                    razor.ViewLocationExpanders.Add(new UI.CustomViewLocationExpander());
                });
            services.AddTransient<UI.Login.LoginService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Verbose);
            loggerFactory.AddDebug(LogLevel.Verbose);

            app.UseDeveloperExceptionPage();
            app.UseIISPlatformHandler();

            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
