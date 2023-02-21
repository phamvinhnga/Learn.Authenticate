
using Learn.Authenticate.Api.Filters;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    internal static class WebServiceBuilder
    {
        internal static void UseWebServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "localhost",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader()
                                                  .AllowAnyMethod();
                    });
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<BadRequestExceptionFilter>();
                options.Filters.Add<BadRequestExceptionFilter>();
                options.Filters.Add<UnauthorizedExceptionFilter>();
                options.Filters.Add<ArgumentNullExceptionFilter>();
            });
        }
    }
}
