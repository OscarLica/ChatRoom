using ChatRoom.Data;
using ChatRoom.Models.DTO;
using ChatRoom.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Implements
{
    public class UserChatService : IUserChatService
    {
        /// <summary>
        ///     Contexto de base de datos
        /// </summary>
        private ApplicationDbContext _Context;

        /// <summary>
        ///     Constructor base, inicializa dependencias
        /// </summary>
        /// <param name="dbContext"></param>
        public UserChatService(ApplicationDbContext dbContext)
        {
            _Context = dbContext;
        }

        /// <summary>
        ///     Guarda los mensaje en la sala de chat
        /// </summary>
        /// <param name="userChatDTO"></param>
        /// <returns></returns>
        public async Task CreateChat(UserChatDTO userChatDTO)
        {
            var user = await _Context.UserChatRooms.FirstOrDefaultAsync(x => x.UserId == userChatDTO.UserId);
            if (user is null)
                await _Context.UserChatRooms.AddAsync(new Models.UserChatRooms { UserId = userChatDTO.UserId, ChatRoomId = userChatDTO.chatroomid });
            var usuario = await _Context.User.FirstOrDefaultAsync(x => x.UserId == userChatDTO.UserId);
            await _Context.Messages.AddAsync(new Models.Message { UserId = usuario.Id, Fecha = DateTime.Now, Content = userChatDTO.mensaje });

            await _Context.SaveChangesAsync();
        }

        public async Task CreateRoom(List<string> users, string room)
        {
            var chatroom = await _Context.ChatRooms.FirstOrDefaultAsync(x => x.ChatRoomId == room);

            if (chatroom != null) return;

            // si aún no existe la sala de chat lo agregamos
            await _Context.ChatRooms.AddAsync(new Models.ChatRooms { ChatRoomId = room });

            // agregmos los usuarios a la sala de chat
            foreach (var user in users)
                await _Context.UserChatRooms.AddAsync(new Models.UserChatRooms { UserId = user, ChatRoomId = room });

            await _Context.SaveChangesAsync();
        }

        /// <summary>
        ///     Consulta los mensaje de la sala de chat
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task<List<UserChatDTO>> GetChatUser(string roomId)
        {
            var result = await (from chatroom in _Context.ChatRooms
                          join user in _Context.UserChatRooms on chatroom.ChatRoomId equals user.ChatRoomId
                          join usuario in _Context.User on user.UserId equals usuario.UserId
                          join sms in _Context.Messages on usuario.Id equals sms.UserId
                          where chatroom.ChatRoomId == roomId
                          select new UserChatDTO
                          {

                              UserId = user.UserId,
                              usuario = usuario.FirstName + " " + usuario.LastName,
                              mensaje = sms.Content,
                              fecha = sms.Fecha

                          }).OrderBy(x => x.fecha).Take(50).ToListAsync();

            return result;
        }
    }
}
