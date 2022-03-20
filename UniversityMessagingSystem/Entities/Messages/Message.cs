namespace UniversityMessagingSystem.Entities.Messages
{
    public class Message
    {
        public int Id { get; set; }

        public string message { get; set; }

        public string fromEmail { get; set; }

        public int fromUser { get; set; }

        public string toEmail { get; set; }

        public int toUser { get; set; }

        public DateTime? sentAt { get; set; }
    }
}
