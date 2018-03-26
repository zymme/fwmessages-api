using System;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FWMessagesAPI.Entities
{
    [Table("messages")]
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }
        public int Message_to { get; set; }
        public int Message_from { get; set; }
        public string message { get; set; }
        public bool Send_sms { get; set; }
        
    }
}
