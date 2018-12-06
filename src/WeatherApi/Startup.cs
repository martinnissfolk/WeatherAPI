using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeatherApi.BusinessLogic;
using WeatherApi.Domain.Data;

namespace WeatherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WeatherContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Culture = new CultureInfo("sv-SE");
                    options.SerializerSettings.DateFormatString =  "MM/dd/yyyy HH:mm:ss";
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IWeatherService, WeatherService>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
                {
                    routes.MapRoute("Default",
                        "{controller}/{action}/{id?}",
                        new {controller = "Default", action = "Index", id = ""}
                );
            });

                
        }
    }
}
