using ChatRoom.Data;
using ChatRoom.Models;
using ChatRoom.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Service.Implements
{
    public class ChatRoomService : IChatRoomService
    {
        /// <summary>
        ///     Contexto de base de datos
        /// </summary>
        private readonly ApplicationDbContext _Context;

        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="dbContext"></param>
        public ChatRoomService(ApplicationDbContext dbContext)
        {
            _Context = dbContext;
        }

        /// <summary>
        ///     Crea una nueva sala de chat
        /// </summary>
        /// <param name="chatRooms"></param>
        /// <returns></returns>
        public async Task<ChatRooms> Create(ChatRooms chatRooms)
        {
            chatRooms.ChatRoomId = Guid.NewGuid().ToString();
            chatRooms.Fecha = DateTime.Now;
            await _Context.ChatRooms.AddAsync(chatRooms);
            await _Context.SaveChangesAsync();
            return chatRooms;
        }

        /// <summary>
        ///     Consulta las sala de chat
        /// </summary>
        /// <returns></returns>
        public async Task<List<ChatRooms>> GetAll()
        => await _Context.ChatRooms.ToListAsync();

        /// <summary>
        ///     Consulta la sala de chat por su id
        /// </summary>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public async Task<ChatRooms> GetByChatRoomId(string chatroomId)
            => await _Context.ChatRooms.FirstOrDefaultAsync(x => x.ChatRoomId == chatroomId);

    }
}
