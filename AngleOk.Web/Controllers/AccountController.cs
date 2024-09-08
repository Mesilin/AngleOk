using AngleOk.Web.Models;
using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Controllers
{
    public class AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            DataManager dataManager)
        : Controller
    {
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
                IdentityUser? user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
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
        public async Task<IActionResult> Register(AccountViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.UserName
                };
                var response = await userManager.CreateAsync(identityUser, model.Password);

                if (response.Succeeded)
                {
                    var employee = new Employee();
                    employee.LastName = model.LastName;
                    employee.FirstName = model.FirstName;
                    employee.Patronymic = model.Patronymic;
                    employee.Email = model.Email;
                    employee.IsActive = model.IsActive;
                    employee.PhoneNumber = model.PhoneNumber;
                    employee.PublicPhone = model.PublicPhone;
                    employee.Position = model.Position;

                    dataManager.Employee.SaveEmployee(employee);
                    return RedirectToAction("Index", "Employees", new { area = "Admin" });
                    //return Redirect("/Admin/Employees");
                }

                var messages = "При попытке регистрации нового пользователя возникла ошибка: " + string.Join(',', response.Errors.Select(s => s.Description));
                ModelState.AddModelError("All", messages);
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
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
