using AutoMapper;
using AutenticaAPI.Data.Dto;
using AutenticaAPI.Models;

namespace AutenticaAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }

    }
}
