using Learn.Authenticate.Entity;
using Learn.Authenticate.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    public static class SqlServiceBuilder
    {
        public static void UseSqlServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void UseMigrationServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
            {
                context?.Database.Migrate();
            }
        }
    }
}
