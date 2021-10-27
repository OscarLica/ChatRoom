using Microsoft.Bot.Builder.AI.Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones.Bot.Services.AI
{
    public interface ILuisAIService
    {
        LuisRecognizer luisRecognizer { get; set; }
    }
}
