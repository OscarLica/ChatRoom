using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Hubs
{
    public interface IChatHub
    {
        Task GetCotizacion(string message);
    }
}
