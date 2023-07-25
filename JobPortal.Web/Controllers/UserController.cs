using JobPortal.Data.Models;
using JobPortal.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;


        public UserController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        /// <summary>
        /// Register Application User!
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");

            }

            var model = new RegisterViewModel();

            return View(model);
        }



        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var applicationUser = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };


            var result = await userManager.CreateAsync(applicationUser, model.Password);

            if (result.Succeeded)
            {

                return RedirectToAction("Login", "User");

            }

            foreach (var item in result.Errors)
            {

                ModelState.AddModelError("", item.Description);


            }

            return View(model);

        }

        /// <summary>
        /// Login Application User!
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");

            }


            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var applicationUser = await userManager.FindByNameAsync(model.Email);

            if (applicationUser != null)
            {
                var result = await signInManager.PasswordSignInAsync(applicationUser, model.Password, false, false);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);

        }

        /// <summary>
        /// Logout Application User
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");


        }
    }
}
