using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ChatRoom.Models;
using ChatRoom.Configuration;

namespace ChatRoom.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ModelConfig(builder);
        }

        public DbSet<ChatRooms> ChatRooms { get; set; }
        public DbSet<UserChatRooms> UserChatRooms { get; set; }
        public DbSet<Users> User{ get; set; }
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Intents> Intents { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ChatRoomConfiguration(modelBuilder.Entity<ChatRooms>());
            new IntentConfiguration(modelBuilder.Entity<Intents>());
        }

    }
}
