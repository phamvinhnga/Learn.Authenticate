using Learn.Authenticate.Biz.Managers;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Biz.Services;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    internal static class InjectionServiceBuilder
    {
        internal static void UseInjectionServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<IUserManager, UserManager>();
        }
    }
}
