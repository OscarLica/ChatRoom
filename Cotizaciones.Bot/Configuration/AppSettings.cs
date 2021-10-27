using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones.Bot.Configuration
{
    public class AppSettings
    {
        /// <summary>
        ///     Id de la aplicacion de Luis
        /// </summary>
        public string LuisId { get; set; }

        /// <summary>
        ///     Id del servicio de cognitivo de azure
        /// </summary>
        public string LuisApiKey { get; set; }

        /// <summary>
        ///     Host de conexión al servicio cognivito
        /// </summary>
        public string LuisHotName { get; set; }

        /// <summary>
        ///     Api de cotizacion
        /// </summary>
        public string ApiCotizacion { get; set; }
    }
}
