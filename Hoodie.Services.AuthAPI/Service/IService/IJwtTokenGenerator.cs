using Hoodie.Services.AuthAPI.Models;

namespace Hoodie.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
