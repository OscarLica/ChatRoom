Module.create("hub", {

});

Module.append("hub", {
    connection: null,
    roomId: "",
    initConnection: () => {

        roomId = $("#ChatRoomId").val();

        // creamos el objeto de conexión
        connection = new signalR.HubConnectionBuilder()
            .withUrl('/Chat')
            .build();

        // indicamos a signalr que inicie, pasando como parametro el nombre del método y el código de la sala
        connection.start().then(() => {
            connection.invoke("AddRoom", roomId);
        }).catch(error => { console.error(error); });
    },

    addEventSend: () => {
        document.getElementById("btnSend").addEventListener("click", (event) => {

            let user = document.getElementById("UserId").value;
            let message = document.getElementById("messageText").value;
            if (!message) return;
            // para enviar el mensaje indicamos a que método del hub queremos que llegue
            connection.invoke("SendMessage", roomId, user, message)
                .catch(error => { console.error(error); });

            // limpiamos la caja de texto
            document.getElementById("messageText").value = "";
            document.getElementById("messageText").focus();

            let userChatDTO = {
                mensaje: message,
                UserId: user,
                chatroomid: $("#ChatRoomId").val()

            };

            $.post("/Chat/SaveMessage", userChatDTO).then(result => { });

            event.preventDefault();

        });

        // recibimos el message
        connection.on("recieveMessage", (room, user, message) => {
            let userChatDTO = {
                mensaje: message,
                UserId: user,
                chatroomid : $("#ChatRoomId").val()

            };
            $.post("/Chat/ChatTemplate", userChatDTO).then(result => {
                if (room !== roomId) return;
                $(".msg_history").append(result);
            });
        });
    }

});
