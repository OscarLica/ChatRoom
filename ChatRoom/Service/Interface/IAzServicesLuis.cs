using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Interface
{
    public interface IAzServicesLuis
    {
        Task<string> GetResponseIntent(string message);
    }
}
