// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Cotizaciones.Bot.Services.AI;
using Cotizaciones.Bot.Services.Cotizacion;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cotizaciones.Bot
{
    public class CotizacionBot : ActivityHandler
    {
        private readonly ILuisAIService _LuiAIService;
        private readonly ICotizacion _Cotizacion;
        public CotizacionBot(ILuisAIService luiAIService, ICotizacion cotizacion)
        {
            _LuiAIService = luiAIService;
            _Cotizacion = cotizacion;
        }
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    //await turnContext.SendActivityAsync(MessageFactory.Text($"Hello world!"), cancellationToken);
                }
            }
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var luisResult = await _LuiAIService.luisRecognizer.RecognizeAsync(turnContext, cancellationToken);

            await Intentions(turnContext, luisResult, cancellationToken);
        }

        private async Task Intentions(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            var topIntent = luisResult.GetTopScoringIntent();
            switch (topIntent.intent)
            {
                case "Cotizacion":
                    await IntentCotizacion(turnContext, luisResult, cancellationToken);
                    break;
                default:
                    await NoIntent(turnContext, luisResult, cancellationToken);
                    break;
            }
        }

        private async Task NoIntent(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("No comprendo la intención");
        }

        private async Task IntentCotizacion(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            var result = await _Cotizacion.GetCotizacion();
            await turnContext.SendActivityAsync(result);
        }
    }
}
