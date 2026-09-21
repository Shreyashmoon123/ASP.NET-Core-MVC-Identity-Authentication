using Identity.Models;
using Identity.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class LoginController : Controller
    {
        public readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;

        public LoginController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users u = new Users()
                {
                    Name = model.Name,
                    Email = model.Email,
                    NormalizedEmail = model.Email,
                    UserName = model.Email,
                    NormalizedUserName = model.Email,
                };
                var result = await userManager.CreateAsync(u, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.Rememberme, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email Id or Password...");
                }
            }
            return View(model);
        }
        public async Task<ActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();

                return RedirectToAction("Login");
            }
            return NotFound();
        }
    }
}
