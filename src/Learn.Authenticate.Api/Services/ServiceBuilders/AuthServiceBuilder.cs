using Learn.Authenticate.Entity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    internal static class AuthServiceBuilder
    {
        private const string _authenticationScheme = "JwtBearer";

        internal static void UseAuthServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = _authenticationScheme;
                options.DefaultChallengeScheme = _authenticationScheme;
            }).AddJwtBearer(_authenticationScheme, options =>
            {
                options.Audience = configuration.GetSection("Authentication:JwtBearer:Audience").Value;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    SaveSigninToken = true,
                    ValidIssuer = configuration.GetSection("Authentication:JwtBearer:Issuer").Value,
                    ValidAudience = configuration.GetSection("Authentication:JwtBearer:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Authentication:JwtBearer:SecurityKey").Value)),
                };
            });
        } 
    }
}
