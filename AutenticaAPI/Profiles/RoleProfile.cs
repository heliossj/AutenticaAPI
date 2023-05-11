using AutoMapper;
using AutenticaAPI.Data.Dto;
using AutenticaAPI.Models;

namespace AutenticaAPI.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Role>();
        }
    }
}
