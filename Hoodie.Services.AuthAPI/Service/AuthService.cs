using Hoodie.Services.AuthAPI.Data;
using Hoodie.Services.AuthAPI.Dto;
using Hoodie.Services.AuthAPI.Models;
using Hoodie.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Hoodie.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;

        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _appDbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null && !isValid) {
                return new LoginResponseDto
                {
                    User = null,
                    Token = ""
                };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            UserDto userDto = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new()
            {
                User = userDto,
                Token = token
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registerationRequestDto)
        {
            ApplicationUser user = new() { 
                 UserName = registerationRequestDto.Email,
                 Email = registerationRequestDto.Email,
                 NormalizedEmail = registerationRequestDto.Email.ToUpper(),
                 Name = registerationRequestDto.Name,
                 PhoneNumber = registerationRequestDto.PhoneNumber,
            };

            try {
                var result = await _userManager.CreateAsync(user,registerationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _appDbContext.ApplicationUsers.First(u => u.UserName == registerationRequestDto.Email);

                    UserDto userDto = new UserDto()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";
                }
                else {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return "Error Encountered";
            }
        }
    }
}
