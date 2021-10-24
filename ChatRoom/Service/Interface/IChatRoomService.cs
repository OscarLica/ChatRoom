using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Interface
{
    public interface IChatRoomService
    {
        /// <summary>
        ///     Crea una nueva sala de chat
        /// </summary>
        /// <param name="chatRooms"></param>
        /// <returns></returns>
        Task<Models.ChatRooms> Create(Models.ChatRooms chatRooms);

        /// <summary>
        ///     Consulta listado de salas de chat
        /// </summary>
        /// <returns></returns>
        Task<List<Models.ChatRooms>> GetAll();

        /// <summary>
        ///     Consulta la sala de chat por su id
        /// </summary>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        Task<Models.ChatRooms> GetByChatRoomId(string chatroomId);
    }
}
