using EmailSending.Helper;
using Identity.Models;
using Identity.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                    EmailHelper sender = new EmailHelper();
                    string msg = "Dear " + model.Name + ",<br/><br/>You are Successfully Registered on Our Web apllication<br/>" +
                        "Your User Id:" + model.Email + "<br/>Password:" + model.Password + "<br/><br/>Regards,</br>Shreyash Katiyar<br/>Kanpur Uttar Prades.";
                    sender.SendMail(model.Email, "SignUp Completed...", msg);

                        
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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            if (signInManager.IsSignedIn(User))
            {
                var user = await userManager.Users
                    .FirstOrDefaultAsync(x => x.Email == userManager.GetUserName(User));

                if (user == null)
                {
                    return NotFound();
                }

                ViewData["Email"] = user.Email;

                return View();
            }

            return RedirectToAction("Login");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var result = await userManager.ChangePasswordAsync(
                user,
                model.CurrentPassword,
                model.Password
            );

            if (result.Succeeded)
            {
                await signInManager.RefreshSignInAsync(user);

                TempData["Message"] = "Password changed successfully.";

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
    }
}
