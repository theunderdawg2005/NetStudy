using System;

namespace NetStudy.Models
{
    public class SingleChat
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }

        public Dictionary<string, string> SessionKeyEncrypted { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}