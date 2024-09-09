using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VirtualMeetingAdmin.Common;
using VirtualMeetingAdmin.Data;
using VirtualMeetingAdmin.Entities;
using VirtualMeetingAdmin.Models;

namespace VirtualMeetingAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;

        public HomeController(ILogger<HomeController> logger, UserContext userContext)
        {
            _logger = logger;
            _context = userContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                string userName = userLogin.UserName;
                string password = userLogin.Password;

                var checkUser = _context.Users.FirstOrDefault(user => user.UserName == userName && user.Password == password);

                if (checkUser != null)
                {
                    HttpContext.Session.SetObject("userLogin", checkUser);

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View("Index", userLogin);
                }

            }
            return RedirectToAction(nameof(Index), userLogin);
            //return View(userLogin);
        }
    }
}
