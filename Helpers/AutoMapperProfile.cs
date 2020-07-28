using AutoMapper;
using VulcanForge.Entities;
using VulcanForge.Models.Users;

namespace VulcanForge.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}