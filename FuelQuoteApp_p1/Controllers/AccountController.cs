using FuelQuoteApp_p1.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuelQuoteApp_p1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("ClientDashBoard", "Client");
                }


                ModelState.AddModelError(string.Empty, "Loging Failed!");

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Register registerInfo)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerInfo.Email, Email = registerInfo.Email };
                var result = await userManager.CreateAsync(user, registerInfo.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");

        }

        public bool RegisterDataValidation(Register registerinfo)
        {
            bool flag = false;
            if ((registerinfo.UserName.Length <= 50) && (registerinfo.UserName != String.Empty))
            {
                if ((Regex.IsMatch(registerinfo.Email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*")) && (registerinfo.Email != String.Empty))
                {
                    if (registerinfo.Password == registerinfo.ConfirmPassword)
                    {
                        flag = true;
                    }
                }
            }
            else
            {
                flag = false;
            }

            return flag;
        }
    }
}