using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models.DTO
{
    public class CotizacionDTO
    {
        /// <summary>
        ///     Simbolo de la cotización
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Fecha
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        ///     Hora
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        ///     Abierto
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        ///     Alsa
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        ///     Baja
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        ///     Cierre
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        ///     Volumen
        /// </summary>
        public int Volume { get; set; }
    }
}
