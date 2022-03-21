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
       
        public IActionResult Index(int userId)
        {
            User user = _context.user.FirstOrDefault(i => i.Id == userId);

            return View(user);
        }

        public void SendMessage(string toEmail, string message, string fromEmail)
        {
            //var fromUser = _context.user.FirstOrDefault(i => i.Email == viewModel.fromEmail);
            var toUser = _context.user.FirstOrDefault(i => i.Email == toEmail);

            if(toUser != null)
            {
                Message mess = new Message
                {
                    toEmail = toEmail,
                    toUser = toUser.Id,
                    message = message,
                    fromEmail = fromEmail,
                    sentAt = DateTime.Now
                };

                _context.messages.Add(mess);
                _context.SaveChanges();
            }
        }

        public JsonResult Messages(string fromEmail)
        {
            var mess = _context.messages.Where(i => i.toEmail == fromEmail).GroupBy(i => i.fromEmail).Select(i => i.ToList().OrderByDescending(i => i.sentAt).LastOrDefault()).ToList();

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(mess);

            return Json(jsonString);
        }

        public JsonResult GetMessages(string messList, string fromEmail)
        {
            if (messList == null || messList == "[]") return Json("[]");

            IEnumerable<Message> temp = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Message>>(messList);

            var x = _context.messages.Where(i => i.toEmail == fromEmail).ToList();

            var newJson = Newtonsoft.Json.JsonConvert.SerializeObject(x);

            foreach (var y in temp)
            {
                var item = x.FirstOrDefault(i => i.Id == y.Id);

                if(item != null)
                {
                    x.Remove(item);
                }
            }

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(x);

            return Json(new { response = json, oldList = newJson});
        }
    }
}
