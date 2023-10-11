using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Identity;
namespace AngleOk.Web.Services
{
    public class AuthenticationService
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;

        public AuthenticationService(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterNewUser(RegisterUser user)
        {
            var identityUser = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.Email
            };
            return await _userManager.CreateAsync(identityUser, user.Password);

        }

        public async Task<SignInResult> Authenticate(LoginUser user)
        {
            return await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, true);
        }
    }
}
