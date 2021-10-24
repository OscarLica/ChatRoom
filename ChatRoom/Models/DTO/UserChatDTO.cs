using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models.DTO
{
    public class UserChatDTO
    {
        public string chatroomid { get; set; }
        public string UserId { get; set; }
        public string usuario { get; set; }
        public string mensaje { get; set; }
        public DateTime fecha { get; set; }
    }
}
