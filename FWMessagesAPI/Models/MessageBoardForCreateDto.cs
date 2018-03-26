using System;

namespace FWMessagesAPI.Models
{
    public class MessageBoardForCreateDto
    {
        public int Id { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }
        public int Message_to { get; set; }
        public int Message_from { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
