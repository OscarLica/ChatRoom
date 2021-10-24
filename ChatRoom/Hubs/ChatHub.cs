using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatRoom.Hubs
{
    public class ChatHub : Hub
    {
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

        public async Task AddRoom(string room) 
        {
            
            // agregamos a la sala
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            // indicamos que alguien se ha conectado a la sada, el connectionId es el identificador unico del signalR
            await Clients.Group(room).SendAsync("ShowWho",$"Alguien se conecto a la sala {Context.ConnectionId}");
        }

        public async Task Online(string user)
        {
            // indicamos que alguien se ha conectado a la sada, el connectionId es el identificador unico del signalR
            await Clients.All.SendAsync("notifyOnline", $"{user} está en linea.");
        }
    }
}
