using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models
{
    public class Message
    {
        /// <summary>
        ///     Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Id del usuario
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     Fecha en que ha enviado el mensaje
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        ///     Contenido del mensaje
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     Propiedad de navegación al usuario
        /// </summary>
        public virtual Users User { get; set; }
    }
}
