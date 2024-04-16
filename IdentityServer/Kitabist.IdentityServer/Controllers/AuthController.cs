using Kitabist.IdentityServer.DTOs;
using Kitabist.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kitabist.IdentityServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var userCredentials = new ApplicationUser()
            {
                Email=userRegisterDto.Email,
                UserName=userRegisterDto.Username,
                Name=userRegisterDto.Name,
                Surname=userRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(userCredentials, userRegisterDto.Password);

            if (result.Succeeded)
            {
                return Ok("User registered successfully");
            }
            else
            {
                return Ok("Problem occured");
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        //{

        //}
    }
}
