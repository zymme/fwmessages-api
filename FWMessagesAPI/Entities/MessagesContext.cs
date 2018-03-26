using System;

using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace FWMessagesAPI.Entities
{
    public class MessagesContext : DbContext
    {
        public MessagesContext(DbContextOptions<MessagesContext> options) : base(options)
        {
        }

        public DbSet<MessageBoard> MessageBoards { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
