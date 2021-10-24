using ChatRoom.Models;
using ChatRoom.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Controllers
{
    public class ChatRoomController : Controller
    {
        /// <summary>
        ///     Servicio de sala de chat
        /// </summary>
        private readonly IChatRoomService _ChatRoomService;

        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="chatRoomService"></param>
        public ChatRoomController(IChatRoomService chatRoomService)
        {
            _ChatRoomService = chatRoomService;
        }

        /// <summary>
        ///     Formulario de chat rooms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Formulario() {
            return View(new ChatRooms { ChatRoomId = Guid.NewGuid().ToString()});
        }

        /// <summary>
        ///     Formulario para crea una nueva sala de chat
        /// </summary>
        /// <param name="chatRooms"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Formulario([FromForm] ChatRooms chatRooms) {

            await _ChatRoomService.Create(chatRooms);
            return Ok();
        }
    }
}
