using AutoMapper;
using Learn.Authenticate.Biz.Dto;
using Learn.Authenticate.Biz.Model;
using Learn.Authenticate.Entity.Entities;
using Microsoft.IdentityModel.Tokens;
using Mysqlx.Crud;
using System.Diagnostics.Contracts;
using System.Text;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace Learn.Authenticate.Api.Services.ServiceBuilders
{
    internal static class AutoMapperServiceBuilder
    {
        internal static void UseAutoMapperServiceBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserSignInInputDto, UserSignInInputModel>();
                cfg.CreateMap<UserSignInInputModel, User>()
                    .ForMember(d => d.PasswordHash, o => o.Ignore());
            });
            services.AddSingleton(config.CreateMapper());
        }
    }
}
