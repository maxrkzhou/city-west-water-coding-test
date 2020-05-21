using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using city_west_water_coding_test.App_Start;
using city_west_water_coding_test.ApplicationLayer;
using city_west_water_coding_test.InfrastructureLayer;
using city_west_water_coding_test.InfrastructureLayer.SchoolDb;
using city_west_water_coding_test.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;

namespace city_west_water_coding_test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<SchoolDbContext>(
                 options => options
                             .UseSqlServer(
                                 Configuration.GetConnectionString("Primary")
                                 ),
                 ServiceLifetime.Transient);

            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<ISchoolService, SchoolService>();

            services.ConfigureSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory
              .AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();
            app
                .EnableSwagger()
                .UseCors(builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                )
                .UseMvc();
        }
    }
}
