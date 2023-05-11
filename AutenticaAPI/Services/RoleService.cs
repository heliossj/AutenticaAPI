using AutenticaAPI.Data.Dto;
using AutenticaAPI.Models;
using AutenticaAPI.Repository;
using AutoMapper;

namespace AutenticaAPI.Services
{
    public class RoleService
    {
        private IMapper _mapper;
        private RoleRepository _rolepository;

        public RoleService(IMapper mapper, RoleRepository roleRepository)
        {
            _mapper = mapper;
            _rolepository = roleRepository;
        }

        public async Task Create(RoleDto role)
        {
            var bean = _mapper.Map<Role>(role);
            var result = await _rolepository.Create(bean);
            if (result is false)
                throw new Exception("Falha ao cadastrar role");
        }


    }
}
