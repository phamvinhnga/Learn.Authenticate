﻿using Learn.Authenticate.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Learn.Authenticate.Entity
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string defaultConnection = _configuration.GetSection("ConnectionString:DefaultConnection").Value;
            string server = _configuration.GetSection("ConnectionString:Server").Value;
            string database = _configuration.GetSection("ConnectionString:Database").Value;
            string UserId = _configuration.GetSection("ConnectionString:UserId").Value;
            string password = _configuration.GetSection("ConnectionString:Password").Value;
            string port = _configuration.GetSection("ConnectionString:Port").Value;
            string version = _configuration.GetSection("ConnectionString:Version").Value;

            var connectionString = string.Format(defaultConnection,
                                              server,
                                              database,
                                              UserId,
                                              password,
                                              database);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(version)),
                    options => options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    )
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { 
                    Id = 1, 
                    Name = "Admin",
                    Email = "Admin@gmail.com", 
                    Surname = "ADMIN", 
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "Admin@gmail.com".ToUpper(),
                    PasswordHash = "\"AQAAAAEAACcQAAAAEMM3WcPhO+pCDtY91ukic7qiLutGRSmMj5UmQtJvUNzacT0ZT9ndKTAWF2NzyNYpWA==\"", ExtentionId = Guid.NewGuid() }
            );
            builder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = 2, Name = "Staff", NormalizedName = "STAFF" }
            );
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 }
            );
            base.OnModelCreating(builder);
        }

        //public DbSet<Category> Category { get;set; }
        //public DbSet<Shop> Shop { get;set; }
        //public DbSet<WebSetting> WebSetting { get;set; }
        public DbSet<Post> Post { get;set; }
        public DbSet<Location> Location { get; set; }
    }
}
