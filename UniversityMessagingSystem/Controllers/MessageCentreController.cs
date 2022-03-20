using Microsoft.AspNetCore.Mvc;
using UniversityMessagingSystem.Data;
using UniversityMessagingSystem.Entities;
using UniversityMessagingSystem.Entities.Messages;
using UniversityMessagingSystem.Models.MessageCentreViewModels;

namespace UniversityMessagingSystem.Controllers
{
    public class MessageCentreController : Controller
    {
        private int executionCount = 0;
        private readonly ILogger<MessageCentreController> _logger;
        private readonly dbContext _context;
        private Timer _timer = null!;

        public MessageCentreController(dbContext context, ILogger<MessageCentreController> logger)
        {
            _context = context;
            _logger = logger;
        }
       
        public IActionResult Index(User user)
        {
            return View(user);
        }

        public void SendMessage(string toEmail)
        {
            //var fromUser = _context.user.FirstOrDefault(i => i.Email == viewModel.fromEmail);
            var toUser = _context.user.FirstOrDefault(i => i.Email == toEmail);

            

            Message mess = new Message
            {
                toEmail = toEmail,
                toUser = toUser.Id,
                message = "abc", 
                fromEmail = "",
                sentAt = DateTime.Now
            };

            _context.messages.Add(mess);
            _context.SaveChanges();
        }

        public JsonResult GetMessages()
        {
            IEnumerable<Message> mess = _context.messages.Where( i => i.sentAt == DateTime.Now).ToList();

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(mess);

            return Json(jsonString);
        }
    }
}
