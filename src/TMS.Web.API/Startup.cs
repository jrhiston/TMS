using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TMS.Database.Contexts;
using TMS.Web.API.Infrastructure.DependencyResolution;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using TMS.Database.Entities.Identity;
using TMS.Web.API.Managers;
using Microsoft.AspNetCore.Routing;

namespace TMS.Web.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<MainContext>(options => 
                options.UseSqlServer(Configuration["DbConfiguration:TMSConnectionString"], b => b.MigrationsAssembly("TMS.Web.API")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<MainContext>()
                .AddDefaultTokenProviders();

            services.AddOpenIddict<ApplicationUser, MainContext>()
                //.AddTokenManager<CustomOpenIddictManager>()
                .DisableHttpsRequirement()
                .UseJsonWebTokens();

            services.AddMvc();

            var container = IoC.Initialize(services);

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();

            app.UseOpenIddict();

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                RequireHttpsMetadata = false,
                Audience = "http://localhost:58292/",
                Authority = "http://localhost:58292/"
            });

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute("React failover", "TMS/{*uri}", new { controller = "Home", action = "TMS" });
        }
    }
}
