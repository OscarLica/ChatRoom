using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models.DTO
{
    public class LuisServiceResponse
    {
        /// <summary>
        ///     Consulta 
        /// </summary>
        public string query { get; set; }

        /// <summary>
        ///     Predicción
        /// </summary>
        public Prediction prediction { get; set; }

        /// <summary>
        ///     Sentiment
        /// </summary>
        public class Sentiment
        {
            public string label { get; set; }
            public double score { get; set; }
        }

        /// <summary>
        ///     Prediction
        /// </summary>
        public class Prediction
        {
            public string topIntent { get; set; }
            public Sentiment sentiment { get; set; }
        }
    }
}
