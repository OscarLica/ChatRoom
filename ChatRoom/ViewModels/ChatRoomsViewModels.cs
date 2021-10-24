using ChatRoom.Models;
using ChatRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.ViewModels
{
    public class ChatRoomsViewModels
    {
        public List<ChatRooms> chatRooms { get; set; }
        public UserChatDTO NewMessage { get; set; }
        public string UserId { get; set; }
        public string ChatRoomId { get; set; }
        public string ChatRoomName { get; set; }
        public List<UserChatDTO> UserChat { get; set; }
    }
}
