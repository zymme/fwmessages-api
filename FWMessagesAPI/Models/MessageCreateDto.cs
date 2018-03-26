using System;
namespace FWMessagesAPI.Models
{
    public class MessageCreateDto
    {
        public DateTime Create_date { get; set; }
        public int Message_to { get; set; }
        public int Message_from { get; set; }
        public string Message { get; set; }
        public bool Send_sms { get; set; }

    }
}
