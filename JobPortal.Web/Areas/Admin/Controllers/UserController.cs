using JobPortal.Services.Data.Interfaces;
using JobPortal.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortal.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        /// <summary>
        /// Get all Users of Application
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task <IActionResult> All()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<UserViewModel> viewModel = await userService.All(userId);


            return View(viewModel);
        }
    }
}
