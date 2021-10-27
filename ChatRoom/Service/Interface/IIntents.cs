using ChatRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Interface
{
    /// <summary>
    ///     Interfaz de intenst
    /// </summary>
    public interface IIntents
    {
        /// <summary>
        ///     Méetodo que consulta una intención
        /// </summary>
        /// <param name="intent"></param>
        /// <returns></returns>
        Intents FindIntent(string intent);
    }
}
