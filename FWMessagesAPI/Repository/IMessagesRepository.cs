using System;

using FWMessagesAPI.Entities;

namespace FWMessagesAPI.Repository
{
    public interface IMessagesRepository
    {
        void AddMessageBoardEntry(MessageBoard message);

        bool Save();
    }
}
