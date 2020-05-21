using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace city_west_water_coding_test.App_Start
{
    public static class SwaggerConfig
    {
        public static IApplicationBuilder EnableSwagger(this IApplicationBuilder app)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "City West Water Code Test API API V1");
                    c.RoutePrefix = string.Empty;
                })
                ;

            return app;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "City West Water Code Test API",
                    Description = "City West Water Code Test API",
                    Contact = new OpenApiContact
                    {
                        Email = "maxrkzhou@hotmail.com",
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(filePath);
            });

            return services;
        }
    }
}
