using Learn.Authenticate.Biz.Managers;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Biz.Services;
using Learn.Authenticate.Entity.Repositories;
using Learn.Authenticate.Entity.Repositories.Interfaces;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    internal static class InjectionServiceBuilder
    {
        internal static void UseInjectionServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            #region Manager
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IPostManager, PostManager>();
            services.AddTransient<IFileManager, FileManager>();
            #endregion End Manager

            #region Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            #endregion End Repository
        }
    }
}
