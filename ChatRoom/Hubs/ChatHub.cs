using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatRoom.Data;
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
        ///     Constructor base, inicializa dependencias
        /// </summary>
        /// <param name="context"></param>
        public ChatHub(ApplicationDbContext context)
        {
            _Context = context;
        }

        /// <summary>
        ///     Cuando se requiera entrar al chat se invoka al metodo
        /// </summary>
        /// <param name="room"></param>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string room, string user, string message) {

            // de los clientes suscritos al room, que reciban el mensaje en una función de lado del cliente que se llama recieveMessage
            await Clients.Group(room).SendAsync("recieveMessage", room, user, message);
        }

        public async Task AddRoom(string user, string room) 
        {
            // agregamos a la sala
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            // indicamos que alguien se ha conectado a la sada, el connectionId es el identificador unico del signalR
            var usuario = await _Context.User.FirstOrDefaultAsync(x => x.UserId == user);
            await Clients.Group(room).SendAsync("ShowWho", user, $"{usuario.FirstName} {usuario.LastName} se ha conectado a la sala de chat");
        }

        public async Task Online(string user)
        {
            // indicamos que alguien se ha conectado a la sada, el connectionId es el identificador unico del signalR
            await Clients.All.SendAsync("notifyOnline", $"{user} está en linea.");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
