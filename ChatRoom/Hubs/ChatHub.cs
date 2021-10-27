using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatRoom.Data;
using ChatRoom.Service.Interface;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Hubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        ///     Contexto de base de datos
        /// </summary>
        private ApplicationDbContext _Context;

        /// <summary>
        ///     Cotización servcice
        /// </summary>
        public IContizacionService _ContizacionService { get; set; }

        /// <summary>
        ///     Servicio de chat de usuarios
        /// </summary>
        private readonly IUserChatService _UserChatService;

        /// <summary>
        ///     Servicio de usuarios
        /// </summary>

        private readonly IUserService _UserService;

        /// <summary>
        ///     Constructor base, inicializa dependencias
        /// </summary>
        /// <param name="context"></param>
        /// <param name="contizacionService"></param>
        /// <param name="userChatService"></param>
        /// <param name="userService"></param>
        public ChatHub(ApplicationDbContext context, IContizacionService contizacionService, IUserChatService userChatService, IUserService userService)
        {
            _Context = context;
            _ContizacionService = contizacionService;
            _UserChatService = userChatService;
            _UserService = userService;
        }

        /// <summary>
        ///     Consulta la cotización
        /// </summary>
        /// <param name="room"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendCotizacion(string room, string message)
        {
            // si el mensaje no contiene dicha palabra clave, retornamos
            if (!message.Replace(" ", "").ToLower().Contains("stock = stock_code".Replace(" ", ""))) return;

            // consultamos la cotización
            var result = await _ContizacionService.GetCotizacion(message);

            // consultamos al usuario bot
            var bot = await _UserService.GetApplicationUser("Bot");
            // si no existe dicho usuario lo creamos
            if (bot is null) await _UserService.CreateUser(new Models.Users { FirstName = "Chat", LastName = "Bot", UserId = "Bot" });
            // guardamos el resultado del bot
            await _UserChatService.CreateChat(new Models.DTO.UserChatDTO { chatroomid = room, UserId = "Bot", mensaje = result });
            // mostramos el mensaje en pantalla
            await Clients.Group(room).SendAsync("ShowCotizacion", room, result);
        }

        /// <summary>
        ///     Cuando se requiera entrar al chat se invoka al metodo
        /// </summary>
        /// <param name="room"></param>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string room, string user, string message)
        {
            // si el mensaj es diferente del código lo guardamos
            if (!message.Replace(" ","").ToLower().Contains("stock = stock_code".Replace(" ", "")))
                await _UserChatService.CreateChat(new Models.DTO.UserChatDTO { chatroomid = room, UserId = user, mensaje = message });

            // de los clientes suscritos al room, que reciban el mensaje en una función de lado del cliente que se llama recieveMessage
            await Clients.Group(room).SendAsync("recieveMessage", room, user, message);
        }

        /// <summary>
        ///     Agregamos una sala de chat
        /// </summary>
        /// <param name="user"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        public async Task AddRoom(string user, string room)
        {
            // agregamos a la sala
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            // indicamos que alguien se ha conectado a la sada, el connectionId es el identificador unico del signalR
            var usuario = await _Context.User.FirstOrDefaultAsync(x => x.UserId == user);
            await Clients.Group(room).SendAsync("ShowWho", user, $"{usuario.FirstName} {usuario.LastName} se ha conectado a la sala de chat");
        }

        /// <summary>
        ///     Indica cuando un usuario está en linea
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task Online(string user)
        {
            // indicamos que alguien se ha conectado a la sada, el connectionId es el identificador unico del signalR
            await Clients.All.SendAsync("notifyOnline", $"{user} está en linea.");
        }

        /// <summary>
        ///     Desconectamos a todos los usuarios
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
