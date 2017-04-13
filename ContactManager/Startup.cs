using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Data;
using ContactManager.Service.Interfaces;
using ContactManager.Service.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ContactManager
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddScoped<IToonContactRepository, ToonContactRepository>();
            services.AddScoped<INieuwContactRepository, NieuwContactRepository>();
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ContactenCore")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            INieuwContactRepository contactRepository)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    new ExceptionHandlerOptions()
                    {
                        ExceptionHandler = async (context) => await context.Response.WriteAsync("Er is iets fout gegaan. Contacteer de site administrator.")
                    });
            }

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Route niet gevonden.");
            });
        }
    }
}
