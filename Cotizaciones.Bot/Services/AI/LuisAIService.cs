using Cotizaciones.Bot.Configuration;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones.Bot.Services.AI
{
    public class LuisAIService : ILuisAIService
    {
        /// <summary>
        ///     luisRecognizer
        /// </summary>
        public LuisRecognizer luisRecognizer { get; set; }

        /// <summary>
        ///     Confiuguraciones
        /// </summary>
        public AppSettings Settings;

        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="options"></param>
        public LuisAIService(IOptions<AppSettings> options)
        {
            Settings = options.Value;
            var app = new LuisApplication(
                Settings.LuisId,
                Settings.LuisApiKey,
                Settings.LuisHotName
                );

            var recognizer = new LuisRecognizerOptionsV3 (app){
            PredictionOptions = new Microsoft.Bot.Builder.AI.LuisV3.LuisPredictionOptions { IncludeInstanceData = true },             
            };

            luisRecognizer = new LuisRecognizer(recognizer);
        }
    }
}
