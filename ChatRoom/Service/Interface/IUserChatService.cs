using ChatRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Interface
{
    public interface IUserChatService
    {
        /// <summary>
        ///     Crea una sala de chat
        /// </summary>
        /// <param name="users"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        Task CreateRoom(List<string> users, string room);

        /// <summary>
        ///     Obtiene los chat por sala
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task<List<UserChatDTO>> GetChatUser(string roomId);

        /// <summary>
        ///     Guarda el chat
        /// </summary>
        /// <param name="userChatDTO"></param>
        /// <returns></returns>
        Task CreateChat(UserChatDTO userChatDTO);
    }
}
