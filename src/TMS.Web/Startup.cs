﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TMS.Web.Services;
using TMS.Web.Data;
using System;
using TMS.Web.DependencyResolution;
using NLog.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using TMS.Web.Options;
using Microsoft.EntityFrameworkCore;
using TMS.Data.Entities.People;

namespace TMS.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            CurrentEnvironment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IHostingEnvironment CurrentEnvironment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Setup options with DI.
            services.AddOptions();

            services.Configure<ApplicationConfigurations>(Configuration);

            services.AddLogging();

            if (CurrentEnvironment.IsEnvironment("Testing"))
            {
                // Add framework services.
                services.AddDbContext<MainContext>(options =>
                    options.UseInMemoryDatabase());
            }
            else
            {
                // Add framework services.
                services.AddDbContext<MainContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TMSConnectionString")));
            }

            services.AddIdentity<PersonEntity, IdentityRole<long>>()
                .AddEntityFrameworkStores<MainContext, long>()
                .AddDefaultTokenProviders();

            //services.AddTMSDatabaseServices(this);

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            var container = IoC.Initialize(services);

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();

            env.ConfigureNLog("nlog.config");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
