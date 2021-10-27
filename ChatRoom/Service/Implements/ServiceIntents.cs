using ChatRoom.Data;
using ChatRoom.Models;
using ChatRoom.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Implements
{
    public class ServiceIntent : IIntents
    {
        /// <summary>
        ///     Context de base de datos
        /// </summary>
        private readonly ApplicationDbContext _Context;

        /// <summary>
        ///     Constructuro base inicializa el contexto de base de datos
        /// </summary>
        /// <param name="context"></param>
        public ServiceIntent(ApplicationDbContext context)
        {
            _Context = context;
        }

        /// <summary>
        ///     Optione una intención por el intent
        /// </summary>
        /// <param name="intent"></param>
        /// <returns></returns>
        public Intents FindIntent(string intent)
        {
            return _Context.Intents.FirstOrDefault(x => x.intent == intent);
        }
    }
}
