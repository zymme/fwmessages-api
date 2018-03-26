using System;

using FWMessagesAPI.Models;

namespace FWMessagesAPI.Services
{
    public interface IMessageBoardService
    {
        MessageBoardForCreateDto AddMessageBoardEntry(MessageBoardForCreateDto message);
    }
}
