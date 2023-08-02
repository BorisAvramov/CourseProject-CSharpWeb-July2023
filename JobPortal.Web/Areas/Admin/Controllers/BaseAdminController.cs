using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static JobPortal.Common.GeneralApplicationConstants;

namespace JobPortal.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Controller for Admin Area and Role Administrator
    /// </summary>

    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
        
    }
}
