using System;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FWMessagesAPI.Entities
{
    [Table("messageboard")]
    public class MessageBoard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public int message_to { get; set; }
        public int message_from { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
