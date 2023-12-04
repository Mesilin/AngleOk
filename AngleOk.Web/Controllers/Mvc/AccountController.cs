using AngleOk.Web.Models;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Controllers.Mvc
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Форма для авторизации
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        /// <summary>
        /// Авторизация на сайте
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return View(model);
        }

        /// <summary>
        /// Форма для регистрации нового пользователя
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [Authorize]
        public IActionResult Register(string returnUrl)
        {
            return View(new AccountViewModel());
        }
        
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.UserName
                };
                var response = await _userManager.CreateAsync(identityUser, model.Password);

                if (response.Succeeded)
                {
                    var employee = new Employee();

                    return Redirect("/");
                    //return Ok($"Новый пользователь {model.Email} успешно зарегистирован");
                }

                var errs = "При попытке регистрации нового пользователя возникла ошибка: " + string.Join(',', response.Errors.Select(s => s.Description));
                ModelState.AddModelError("All", errs);
            }
            return View(model);
        }

        /// <summary>
        /// Выход
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
