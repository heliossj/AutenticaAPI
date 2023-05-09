using AutenticaAPI.Data.Dto;
using AutenticaAPI.Models;
using AutoMapper;
using AutenticaAPI.Data.Dto;
using AutenticaAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace AutenticaAPI.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Register(CreateUserDto user)
        {
            User userCreate = _mapper.Map<User>(user);
            var result = await _userManager.CreateAsync(userCreate, user.Password);
            if (!result.Succeeded)
                throw new Exception("Falha ao cadastrar usuário");
        }

        public async Task<string> Login(LoginUserDto user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, true);
            //if (!result.)


            if (result.IsLockedOut)
                throw new ApplicationException("Usuário bloqueado");
            if (!result.Succeeded)
                throw new ApplicationException("Usuário não autenticado!");
            var userAuth = _signInManager.UserManager.Users.FirstOrDefault(usr => usr.NormalizedUserName == user.Username.ToUpper());
            var token = _tokenService.GenerateToken(userAuth);
            return token;
        }
    }
}
