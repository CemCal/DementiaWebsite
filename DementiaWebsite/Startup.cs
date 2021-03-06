﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DementiaWebsite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DementiaWebsite
{
    public class Startup
    {
        readonly IConfigurationRoot configuration;

        public Startup(IHostingEnvironment env)
        {
                 configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile(env.ContentRootPath + "/appsettings.json")
                .AddJsonFile(env.ContentRootPath + "/appsettings.Development.json", true)
                .Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {
                EnableDeveloperExceptions = configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions")
            });

            //this method should always be implemented with app.UseMvc()
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              FeatureToggles features)
        {

            if (features.EnableDeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }
            /*
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                {
                    throw new Exception("ERROR!");
                }
                await next();

            });*/

            //routing method which will look for "Controllers","/public methods in those classes and what parameters they might have
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=Index}/{id?}");
            });
         
            app.UseFileServer();
        }
    }
}
