using Cotizaciones.Bot.Configuration;
using Cotizaciones.Bot.DTO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cotizaciones.Bot.Services.Cotizacion
{
    public class Cotizacion : ICotizacion
    {
        /// <summary>
        ///     Cliente http
        /// </summary>
        public HttpClient httpClient;

        /// <summary>
        ///     Configuraciones
        /// </summary>
        public AppSettings Settings;

        /// <summary>
        ///     Constructor base
        /// </summary>
        /// <param name="options"></param>
        public Cotizacion(IOptions<AppSettings> options)
        {
            httpClient = new HttpClient();

            Settings = options.Value;
        }

        /// <summary>
        ///     Obtiene la cotización
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetCotizacion()
        {
            // Consulto la cotización
            var response = await httpClient.GetAsync(Settings.ApiCotizacion);

            // leo el resultado
            var strResponseContent = await response.Content.ReadAsStringAsync();

            // configuro Csv para leer el archivo csv
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            // leo el archivo csv
            var reader = new CsvReader(new StringReader(strResponseContent), config);

            // mapeo los datos aun objeto
            var records = reader.GetRecords<CotizacionDTO>().ToList();

            // obte
            var closeValue = records.FirstOrDefault()?.Close ?? default(decimal);
            return $"APPL.US quote is ${closeValue} per share";

        }
    }
}
