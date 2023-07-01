using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
