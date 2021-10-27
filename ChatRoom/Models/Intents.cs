using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models
{
    public class Intents
    {

        /// <summary>
        ///     Primary key de la entidad
        /// </summary>
        [Key]
        public int IntentId { get; set; }

        /// <summary>
        ///     código de la intentnción
        /// </summary>
        public string intent { get; set; }

        /// <summary>
        ///     Respuesta para cada intención
        /// </summary>
        public string response { get; set; }
    }
}
