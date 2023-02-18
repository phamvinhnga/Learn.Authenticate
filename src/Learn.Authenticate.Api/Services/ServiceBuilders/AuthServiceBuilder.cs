using Learn.Authenticate.Api.Filters;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    internal static class AuthServiceBuilder
    {
        internal static void UseAuthServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration.GetSection("JWT:ValidAudience").Value,
                ValidIssuer = configuration.GetSection("JWT:ValidIssuer").Value,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:SecurityKey").Value))
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = tokenValidationParameters;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;

            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyExtention.Manager_Account_Staff, policy => policy.RequireClaim(PolicyExtention.Manager_Account_Staff));
            });

            services.AddScoped<AdminRoleFilter>();
            services.AddScoped<StaffRoleFilter>();
        }
    }
}
