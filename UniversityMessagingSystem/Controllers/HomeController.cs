using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityMessagingSystem.Data;
using UniversityMessagingSystem.Entities;
using UniversityMessagingSystem.Models;

namespace UniversityMessagingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContext _context;

        public HomeController(ILogger<HomeController> logger, dbContext context)
        {
            _logger = logger;
            _context = context;
         }

        public IActionResult Index()
        {
            User user = _context.user.FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            User user = _context.user.FirstOrDefault(x => x.Email == email);

            if (user == null) return RedirectToAction("Index");

            if(user.Password != password) return RedirectToAction("Index");

            return RedirectToAction("Index", "MessageCentre", new {userId = user.Id});
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if(user == null) return RedirectToAction("Index");

            _context.user.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
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
    }
}