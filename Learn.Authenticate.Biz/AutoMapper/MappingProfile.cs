using AutoMapper;
using Learn.Authenticate.Biz.Dto;
using Learn.Authenticate.Biz.Model;
using Learn.Authenticate.Entity.Entities;

namespace Learn.Authenticate.Biz.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignUpInputDto, UserSignUpInputModel>();
            CreateMap<UserSignUpInputModel, User>()
                .ForMember(d => d.PasswordHash, o => o.Ignore());
            CreateMap<UserSignInOutputModel, UserSignInOutputDto>();
            CreateMap<User, CurrentUserOutputModel>();
            CreateMap<CurrentUserOutputModel, CurrentUserOutputDto>();
        }
    }
}
