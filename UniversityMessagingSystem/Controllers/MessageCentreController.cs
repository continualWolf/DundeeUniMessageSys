using Microsoft.AspNetCore.Mvc;

namespace UniversityMessagingSystem.Controllers
{
    public class MessageCentreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
