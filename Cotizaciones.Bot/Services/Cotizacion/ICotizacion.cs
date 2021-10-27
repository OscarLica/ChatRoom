using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones.Bot.Services.Cotizacion
{
    public interface ICotizacion
    {
        Task<string> GetCotizacion();
    }
}
