using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Interface
{
    public interface IAzServicesLuis
    {
        /// <summary>
        ///     Consulta intensión devuelta pior el app de Azure Luis en base de datos
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<string> GetResponseIntent(string message);
    }
}
