using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models
{
    public class ChatRooms
    {
        /// <summary>
        ///     Primary key de la entidad
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///    Identificador de la sala de chat
        /// </summary>
        public string ChatRoomId { get; set; }

        /// <summary>
        ///     Nombre del chat es opciones
        /// </summary>
        public string ChatRoomName { get; set; }

        /// <summary>
        ///     Fecha de creación de la sala de chat
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        ///     Descripción de la sala de chat
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        ///     Lista de usuario de la sala de chat
        /// </summary>
        public virtual List<UserChatRooms> Users { get; set; }
    }
}
