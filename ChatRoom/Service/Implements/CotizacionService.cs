using ChatRoom.Configuration;
using ChatRoom.Models.DTO;
using ChatRoom.Service.Interface;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatRoom.Service.Implements
{
    public class CotizacionService : IContizacionService
    {
        /// <summary>
        ///     Cliente http
        /// </summary>
        public HttpClient httpClient;

        /// <summary>
        ///     Configuraciones
        /// </summary>
        public AppSettings Settings;
        public IIntents _ServiceIntent { get; set; }
        public IAzServicesLuis _AzServicesLuis { get; set; }

        /// <summary>
        ///     Constructor base
        /// </summary>
        /// <param name="options"></param>
        public CotizacionService(IOptions<AppSettings> options, IIntents serviceIntent, IAzServicesLuis azServicesLuis)
        {
            httpClient = new HttpClient();

            Settings = options.Value;
            _ServiceIntent = serviceIntent;
            _AzServicesLuis = azServicesLuis;
        }
        public async Task<string> GetCotizacion(string message)
        {
            // consultamos la intensión del usuario
            var intent = await _AzServicesLuis.GetResponseIntent(message);

            if (intent == "NU") return "No comprendo la intensión";

            // Consulto la cotización
            var response = await httpClient.GetAsync(intent);

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
