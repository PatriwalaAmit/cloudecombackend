using Microsoft.AspNetCore.Mvc;
using VirtualMeetingAdmin.Common;
using VirtualMeetingAdmin.Entities;

namespace VirtualMeetingAdmin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetObject<Users>("userLogin");

            if (user != null)
            {
                ViewBag.UserName = user.UserName;
            }
            return View();
        }
    }
}
