using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models.DTO
{
    public class UserRoomDTO : Users
    {
        public string roomId { get; set; }
    }
}
