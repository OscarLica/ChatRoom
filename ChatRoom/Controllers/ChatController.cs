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

        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="userChatService"></param>
        /// <param name="chatRoomService"></param>
        public ChatController(UserManager<IdentityUser> userManager, IUserChatService userChatService, IChatRoomService chatRoomService)
        {
            _UserManager = userManager;
            _UserChatService = userChatService;
            _ChatRoomService = chatRoomService;
        }

        /// <summary>
        ///     Vista principal Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _UserManager.GetUserAsync(User);
            ChatRoomsViewModels chatRoomsViewModels = new ChatRoomsViewModels
            {
                UserId = currentUser.Id,
                chatRooms = await _ChatRoomService.GetAll()

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
        ///     Guarda el mensaje en base de datos
        /// </summary>
        /// <param name="userChatDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveMessage(UserChatDTO userChatDTO) {
            await _UserChatService.CreateChat(userChatDTO);
            return Ok("Mensaje guardado");
        }

        /// <summary>
        ///     Template del chat
        /// </summary>
        /// <param name="userChatDTO"></param>
        /// <returns></returns>
        public async Task<IActionResult> ChatTemplate(UserChatDTO userChatDTO)
        {
            var currentUser = await _UserManager.GetUserAsync(User);
            userChatDTO.fecha = DateTime.Now;
            return View(new ChatRoomsViewModels { NewMessage = userChatDTO, UserId = currentUser.Id });
        }
    }
}
