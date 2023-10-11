using AngleOk.Web.Services;
using Data.AngleOk.Model.Models;
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
                    return Ok($"Новый пользователь {user.Email} успешно зарегистирован");
                }

                var errs = "При попытке регистрации нового пользователя возникла ошибка: " + string.Join(',', response.Errors.Select(s => s.Description));

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

                if (response.Succeeded)
                {
                    return Ok($"Пользователь {user.Email} успешно вошел в систему");
                }

                if (response.IsNotAllowed) 
                { 
                    return BadRequest("Пользователю запрещен вход в систему");
                }

                if (response.IsLockedOut)
                {
                    return BadRequest("Пользователь заблокирован");
                }
                return BadRequest("Не удалось выполнить вход. Неверный логин или пароль");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
