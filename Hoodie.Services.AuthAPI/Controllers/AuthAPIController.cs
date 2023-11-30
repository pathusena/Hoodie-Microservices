using Hoodie.Services.AuthAPI.Dto;
using Hoodie.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hoodie.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _responseDto;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _responseDto = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto) {
            var errorMessage = await _authService.Register(registrationRequestDto);
            if (errorMessage.Count() > 0) { 
                _responseDto.IsSuccess = false;
                _responseDto.Message = errorMessage;
                return BadRequest(errorMessage);
            }
            return Ok(_responseDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var loginResponse = await _authService.Login(loginRequestDto);
            if (loginResponse.User == null) { 
                _responseDto.IsSuccess=false;
                _responseDto.Message = "Username or password incorrect";
                return BadRequest(_responseDto);
            }
            _responseDto.Ressult = loginResponse;
            return Ok(_responseDto);
        }
    }
}
