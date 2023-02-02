using AutoMapper;
using Learn.Authenticate.Biz.AutoMapper;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    internal static class AutoMapperServiceBuilder
    {
        internal static void UseAutoMapperServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            services.AddSingleton(config.CreateMapper());
        }
    }
}
