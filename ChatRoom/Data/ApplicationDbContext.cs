using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ChatRoom.Models;

namespace ChatRoom.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ChatRooms> ChatRooms { get; set; }
        public DbSet<UserChatRooms> UserChatRooms { get; set; }
        public DbSet<Users> User{ get; set; }
        public DbSet<Message> Messages{ get; set; }
    }
}
