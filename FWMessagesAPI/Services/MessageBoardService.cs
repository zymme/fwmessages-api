using System;

using Microsoft.Extensions.Logging;

using FWMessagesAPI.Models;

using FWMessagesAPI.Repository;

namespace FWMessagesAPI.Services
{
    public class MessageBoardService : IMessageBoardService
    {
        private readonly IMessagesRepository _messagesRepository;
        private readonly ILogger<MessageBoardService> _logger;

        public MessageBoardService(ILogger<MessageBoardService> logger, IMessagesRepository repository)
        {
            _messagesRepository = repository;
            _logger = logger;
        }

        public MessageBoardForCreateDto AddMessageBoardEntry(MessageBoardForCreateDto message)
        {
            try 
            {
                Console.WriteLine("Inside AddMessageBoardEntry() ");

                var messageboardentry = AutoMapper.Mapper.Map<Entities.MessageBoard>(message);

                _messagesRepository.AddMessageBoardEntry(messageboardentry);

                if (!_messagesRepository.Save())
                {
                    throw new Exception("Error occurred during AddMessageBoardEntry() of User ...");
                }

                return message;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error in AddMessageBoardEntry() {e.Message}");
                _logger.LogError($"Error in AddMessageBoardEntry() {e.Message}");

                return null;
            }
        }
    }
}
