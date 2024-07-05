using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<staff> _userManager;
        private readonly SignInManager<staff> _signInManager;
        public AuthController(UserManager<staff> userManager, SignInManager<staff> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Pass, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Lưu thông tin vào session
                    HttpContext.Session.SetString("UserEmail", model.Username);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
