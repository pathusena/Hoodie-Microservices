using Hoodie.Web.Models;
using Hoodie.Web.Service.IService;
using Hoodie.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Hoodie.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ResponseDto responseDto = await _authService.LoginAsync(loginRequestDto);
            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
                return RedirectToAction("Index", "Home");

            }
            else {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(loginRequestDto);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roles = new List<SelectListItem>
            {
                new SelectListItem{ Text = StaticDetails.RoleAdmin, Value = StaticDetails.RoleAdmin},
                new SelectListItem{ Text = StaticDetails.RoleCustomer, Value = StaticDetails.RoleCustomer}
            };
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto registrationRequestDto)
        {
            ResponseDto responseDto = await _authService.RegistrationAsync(registrationRequestDto);
            if (responseDto != null && responseDto.IsSuccess) {
                if (string.IsNullOrEmpty(registrationRequestDto.RoleName)) {
                    registrationRequestDto.RoleName = StaticDetails.RoleCustomer;
                }
                ResponseDto assignRole = await _authService.AssignRoleAsync(registrationRequestDto);
                if (assignRole != null && assignRole.IsSuccess) {
                    TempData["success"] = "Registration successful";
                    return RedirectToAction(nameof(Login));
                }
            }

            var roles = new List<SelectListItem>
            {
                new SelectListItem{ Text = StaticDetails.RoleAdmin, Value = StaticDetails.RoleAdmin},
                new SelectListItem{ Text = StaticDetails.RoleCustomer, Value = StaticDetails.RoleCustomer}
            };
            ViewBag.Roles = roles;
            return View(registrationRequestDto);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
