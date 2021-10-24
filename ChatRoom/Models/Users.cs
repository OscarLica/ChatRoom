using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models
{
    public class Users
    {
        /// <summary>
        ///     Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Id del usuario que se ha registrado en la applicación
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Primero nombre
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Apellido
        /// </summary>
        public string LastName { get; set; }
    }
}
