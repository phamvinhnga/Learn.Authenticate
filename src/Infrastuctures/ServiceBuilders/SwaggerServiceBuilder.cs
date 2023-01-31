using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastuctures.ServiceBuilders
{
    public static class SwaggerServiceBuilder
    {
        public static void UseSwaggerApplicationBuilder(this IApplicationBuilder app, IConfiguration configuration)
        {
            if (!configuration.GetValue<bool>("Swagger:Enabled", false)) return;

            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void AddSwaggerServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            if (!configuration.GetValue<bool>("Swagger:Enabled", false)) return;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo.Service", Version = "v1" });
                // Define the BearerAuth scheme that's in use
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                     }
                });
            });
        }
    }
}
