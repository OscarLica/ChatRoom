using ChatRoom.Data;
using ChatRoom.Service.Implements;
using ChatRoom.Service.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TestProject.Config;

namespace TestProject
{
    public class Tests
    {
        /// <summary>
        ///     Contexto de base de datos, configurado para usar una instancia de base de datos en memoria
        /// </summary>
        private ApplicationDbContext _Context;

        private ChatRoomService ChatRoomService;

        [SetUp]
        public void Setup()
        {
            _Context = ApplicationDbContextInMemory.Get();
            ChatRoomService = new ChatRoomService(_Context);
        }

        [Test]
        public async Task CreateChatRoom()
        {
            // arrange
            var chatroom = new ChatRoom.Models.ChatRooms
            {
                ChatRoomName = "#Development Chat Room",
                Descripcion = "Sala de chat para desarrolladores"
            };

            // act
            chatroom = await ChatRoomService.Create(chatroom);

            // asssert
            Assert.IsTrue(chatroom.Id > 0);
        }

        [Test]
        public async Task GetAllChatRooms()
        {
            // act
            await ChatRoomService.GetAll();

            // asssert
            Assert.Pass();
        }
    }
}