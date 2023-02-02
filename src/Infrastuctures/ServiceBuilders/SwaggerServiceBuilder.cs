using Microsoft.AspNetCore.Authentication.JwtBearer;
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

        public static void UseSwaggerServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            if (!configuration.GetValue<bool>("Swagger:Enabled", false)) return;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Learn.Authenticate.Api", Version = "v1" });
                // Define the BearerAuth scheme that's in use
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new string[] {}
                     }
                });
            });
        }
    }
}
