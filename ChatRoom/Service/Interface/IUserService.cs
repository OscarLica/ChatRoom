using ChatRoom.Models;
using ChatRoom.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Interface
{
    public interface IUserService
    {
        /// <summary>
        ///     Crea un nuevo usuario
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        Task<Users> CreateUser(Users users);

        /// <summary>
        ///     Consulta el usuario por el id del usuario de la aplicación
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Users> GetApplicationUser(string userId);

        /// <summary>
        ///     Consulta todos los usuarios
        /// </summary>
        /// <returns></returns>
        Task<List<UserRoomDTO>> GetAllUsers();
    }
}
