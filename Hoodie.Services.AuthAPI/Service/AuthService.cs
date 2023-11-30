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
        public AuthService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
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
