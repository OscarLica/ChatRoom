/*  creamos el modulo hub*/
Module.create("hub", {

});

/* agregamos al modulo las funciona de inicializar conexión y enviar mensaje*/
Module.append("hub", {
    connection: null,
    roomId: "",
    recieve: false,
    self: this,

    /**
     *  Inicializa la conexión de una sala de chat
     * @param {any} room
     */
    initConnection: (room) => {

        roomId = room;

        // creamos el objeto de conexión
        connection = new signalR.HubConnectionBuilder()
            .withUrl('/Chat')
            .build();

        // indicamos a signalr que inicie, pasando como parametro el nombre del método y el código de la sala
        connection.start().then(() => {
            connection.invoke("AddRoom", document.getElementById("UserId").value, roomId);
        }).catch(error => { console.error(error); });

        return connection;
    },

    /** Envia el mensaje a la sala de chat */
    addEventSend: () => {
        if (!document.getElementById("btnSend")) return;

        document.getElementById("btnSend").addEventListener("click", (event) => {

            let user = document.getElementById("UserId").value;
            let message = document.getElementById("messageText").value;

            if (!message) return;

            // para enviar el mensaje indicamos a que método del hub queremos que llegue
            connection.invoke("SendMessage", roomId, user, message)
                .catch(error => { console.error(error); });

            // enviamos el mensaje para ejecutar la cotización
            connection.invoke("SendCotizacion", roomId, message)
                .catch(error => { console.error(error); });

            // limpiamos la caja de texto
            document.getElementById("messageText").value = "";
            document.getElementById("messageText").focus();

            event.preventDefault();

        });

        /* recibimos el mensaje enviado*/
        connection.on("recieveMessage", (room, user, message) => {

            let userChatDTO = {
                mensaje: message,
                UserId: user,
                chatroomid: $("#ChatRoomId").val()
            };

            $.post("/Chat/ChatTemplate", userChatDTO).then(result => {
                if (room !== roomId) return;
                $(".msg_history").append(result);
                $('.msg_history').scrollTop($('.msg_history')[0].scrollHeight);
            });

        });

        /*  Devuelve la cotización*/
        connection.on("ShowCotizacion", (room, message) => {

            let userChatDTO = {
                mensaje: message,
                UserId: "Bot",
                chatroomid: $("#ChatRoomId").val()
            };

            $.post("/Chat/ChatTemplate", userChatDTO).then(result => {
                if (room !== roomId) return;
                $(".msg_history").append(result);
                $('.msg_history').scrollTop($('.msg_history')[0].scrollHeight);
            });

        });

        /*recibimos el message indicamos que alguin ha iniciado sesión en la sala de chat*/
        connection.on("ShowWho", (user, message) => {
            let usuario = document.getElementById("UserId").value;
            if (usuario !== user)
                toastr["success"](message);
        });
    }

});
