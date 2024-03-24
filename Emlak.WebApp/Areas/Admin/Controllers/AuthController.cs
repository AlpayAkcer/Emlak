using Emlak.Dto.UserDto;
using Emlak.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<UserAdmin> _userManager;
        private readonly SignInManager<UserAdmin> _signInManager;

        public AuthController(UserManager<UserAdmin> userManager, SignInManager<UserAdmin> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("ID", user.Id);
                        HttpContext.Session.SetString("FullName", user.FullName);
                        HttpContext.Session.SetString("Email", user.Email);

                        return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("Hata", "E-posta adresiniz veya Şifre Hatalı");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("Hata", "E-posta adresiniz veya Şifre Hatalı");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Remove("Email");
            return RedirectToAction("Login", "Auth", new { Area = "Admin" });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
