using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Interface
{
    /// <summary>
    ///     Interface de cotización
    /// </summary>
    public interface IContizacionService
    {
        /// <summary>
        ///     Consulta la cotización
        /// </summary>
        /// <returns></returns>
        Task<string> GetCotizacion(string ApiCotizacion);
    }
}
