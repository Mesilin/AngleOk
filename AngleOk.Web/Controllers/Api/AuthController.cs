using AngleOk.Web.Services;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService authService;
        public AuthController(AuthenticationService serv)
        {
            authService = serv;
        }

        [HttpPost]
        [ActionName("register")]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            try
            {
                
                var response = await authService.RegisterNewUser(user);

                if (response.Succeeded)
                {
                    return Ok($"User {user.Email} is register successfully");
                }

                var errs = "При попытке регистрации нового пользователя возникла ошибка: "+string.Join(',', response.Errors.Select(s=>s.Description));

                return BadRequest(errs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("authenticate")]
        public async Task<IActionResult> AuthUser(LoginUser user)
        {
            try
            {
                var response = await authService.Authenticate(user);
                if (response)
                    return Ok($"User {user.Email} is authenticated successfully");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
