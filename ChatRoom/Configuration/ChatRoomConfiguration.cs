using ChatRoom.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Configuration
{
    public class ChatRoomConfiguration
    {
        public ChatRoomConfiguration(EntityTypeBuilder<ChatRooms> entityBuilder)
        {
            var chatRoomDefault = new ChatRooms
            {
                Id = 1,
                ChatRoomName = "#General",
                ChatRoomId = Guid.NewGuid().ToString(),
                Fecha = DateTime.Now,
                Descripcion = "Chat de generales, información de interes para toda la organización"
                
            };

            entityBuilder.HasData(chatRoomDefault);
        }
    }
}
