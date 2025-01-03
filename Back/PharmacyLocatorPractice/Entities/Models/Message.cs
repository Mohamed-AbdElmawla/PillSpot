namespace Entities.Models
{
    public class Message
    {
        public string MessageId { get; set; } = Guid.NewGuid().ToString();
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime? ReadAt { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }

        public User Receiver { get; set; }
        public User Sender { get; set; }
    }
}
