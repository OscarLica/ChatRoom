using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models
{
    public class UserChatRooms
    {
        /// <summary>
        ///     Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Id del chat room
        /// </summary>
        public string ChatRoomId { get; set; }

        /// <summary>
        ///     Id del usuario que se ha registrado en la applicación
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Mensajes del usuario
        /// </summary>
        public virtual List<Message> Messages { get; set; }

        /// <summary>
        ///     Sala de chat al que pertenece
        /// </summary>
        public virtual ChatRooms ChatRoom { get; set; }
    }
}
