using ChatRoom.Models.DTO;
using ChatRoom.Service.Interface;
using ChatRoom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        /// <summary>
        ///     Manejador de usuarios
        /// </summary>
        private readonly UserManager<IdentityUser> _UserManager;

        /// <summary>
        ///     Servicio de chat de usuarios
        /// </summary>
        private readonly IUserChatService _UserChatService;

        /// <summary>
        ///     Servicio de sala de chat
        /// </summary>
        private readonly IChatRoomService _ChatRoomService;

        private readonly IUserService _UserService;

        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="userChatService"></param>
        /// <param name="chatRoomService"></param>
        public ChatController(UserManager<IdentityUser> userManager, IUserChatService userChatService, IChatRoomService chatRoomService, IUserService userService)
        {
            _UserManager = userManager;
            _UserChatService = userChatService;
            _ChatRoomService = chatRoomService;
            _UserService = userService;
        }

        /// <summary>
        ///     Vista principal Index
        /// </summary>
        /// <returns></returns>
        [HttpGet("Chat/{chatroomId}")]
        public async Task<IActionResult> Index(string chatroomId = null)
        {
            var currentUser = await _UserManager.GetUserAsync(User);
            var chatroom = await _ChatRoomService.GetByChatRoomId(chatroomId);
            ChatRoomsViewModels chatRoomsViewModels = new ChatRoomsViewModels
            {
                UserId = currentUser.Id,
                ChatRoomId = chatroom == null ? null : chatroomId,
                chatRooms = await _ChatRoomService.GetAll(),
                ChatRoomName = chatroom?.ChatRoomName,
                UserChat = string.IsNullOrEmpty(chatroomId) ? new List<UserChatDTO>() :  await _UserChatService.GetChatUser(chatroomId)
            };

            return View(chatRoomsViewModels);
        }

        /// <summary>
        ///     Consulta los chat por sala
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>

        [HttpGet("Chat/ChatRooms/{room}")]
        public async Task<IActionResult> ChatRooms(string room)
        {
            var currentUser = await _UserManager.GetUserAsync(User);
            var chatroom = await _ChatRoomService.GetByChatRoomId(room);
            ChatRoomsViewModels chatRoomsViewModels = new ChatRoomsViewModels
            {
                UserId = currentUser.Id,
                ChatRoomId = room,
                ChatRoomName = chatroom.ChatRoomName,
                UserChat = await _UserChatService.GetChatUser(room)

            };
            return View("ChatRooms", chatRoomsViewModels);
        }

        /// <summary>
        ///     Template del chat
        /// </summary>
        /// <param name="userChatDTO"></param>
        /// <returns></returns>
        public async Task<IActionResult> ChatTemplate(UserChatDTO userChatDTO)
        {
            var currentUser = await _UserManager.GetUserAsync(User);
            if (userChatDTO.UserId == "Bot")
            {
                userChatDTO.usuario = "Chat Bot";
            }
            else {

                var usuario = await _UserService.GetApplicationUser(userChatDTO.UserId);
                userChatDTO.usuario = $"{usuario.FirstName} {usuario.LastName}";
            }
            userChatDTO.fecha = DateTime.Now;
            return View(new ChatRoomsViewModels { NewMessage = userChatDTO, UserId = currentUser.Id });
        }
    }
}
