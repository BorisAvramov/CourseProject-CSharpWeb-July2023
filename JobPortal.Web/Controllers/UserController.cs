using JobPortal.Data.Models;
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


        //[HttpGet]
        //[AllowAnonymous]

        //public IActionResult Register()
        //{
        //    if (User?.Identity?.IsAuthenticated ?? false)
        //    {
        //        return RedirectToAction("All", "Movies");

        //    }

        //    var model = new RegisterViewModel();

        //    return View(model);
        //}


    }
}
