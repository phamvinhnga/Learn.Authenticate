
using Learn.Authenticate.Api.Filters;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    internal static class WebServiceBuilder
    {
        internal static void UseWebServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<BadRequestExceptionFilter>();
            });
        }
    }
}
