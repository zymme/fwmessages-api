using System;

using Microsoft.Extensions.Logging;

using FWMessagesAPI.Entities;

namespace FWMessagesAPI.Repository
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly MessagesContext _messageContext;
        private readonly ILogger<MessagesRepository> _logger;

        public MessagesRepository(MessagesContext messagecontext, ILogger<MessagesRepository> logger)
        {
            _messageContext = messagecontext;
            _logger = logger;
        }

        public void AddMessageBoardEntry(MessageBoard message)
        {
            var saveresult = _messageContext.Add(message);
            Console.WriteLine($"Saveresult {saveresult}");
        }

        public bool Save()
        {
            try 
            {
                var changes = _messageContext.SaveChanges();

                return (changes >= 0);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error in Save()  {e.Message}");
                _logger.LogError($"Error in Save()  {e.Message}");
                return false;
            }
        }
    }
}
