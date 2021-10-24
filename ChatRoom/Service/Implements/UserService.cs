using ChatRoom.Data;
using ChatRoom.Models;
using ChatRoom.Models.DTO;
using ChatRoom.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Implements
{
    public class UserService : IUserService
    {
        /// <summary>
        ///     Contexto de base de datos
        /// </summary>
        private readonly ApplicationDbContext _Context;

        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public UserService(ApplicationDbContext applicationDbContext)
        {
            _Context = applicationDbContext;
        }

        /// <summary>
        ///     Crea un nuevo usuario
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Users> CreateUser(Users users)
        {
            await _Context.User.AddAsync(users);
            await _Context.SaveChangesAsync();
            return users;
        }

        /// <summary>
        ///     Consulta listado de usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserRoomDTO>> GetAllUsers()
        {
            return await (from user in _Context.User
                          join useroom in _Context.UserChatRooms on user.UserId equals useroom.UserId into userch
                          from pco in userch.DefaultIfEmpty()
                          select new UserRoomDTO
                          {
                              UserId = user.UserId,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              roomId = pco == null ? Guid.NewGuid().ToString() : pco.ChatRoomId
                          }).ToListAsync();
        }

        /// <summary>
        ///     Consulta el usuario por el user id de la aplicación
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Users> GetApplicationUser(string userId)
        {
            return await _Context.User.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
