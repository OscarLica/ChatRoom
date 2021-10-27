using ChatRoom.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Configuration
{
    public class IntentConfiguration
    {
        public IntentConfiguration(EntityTypeBuilder<Intents> entityBuilder)
        {
            var chatRoomDefault = new Intents
            {
                IntentId = 1,
                intent = "Cotizacion",
                response = "https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv",

            };

            entityBuilder.HasData(chatRoomDefault);
        }
    }
}
