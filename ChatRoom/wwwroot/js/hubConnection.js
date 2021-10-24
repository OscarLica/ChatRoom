
let roomId = $("#ChatRoomId").val();

// creamos el objeto de conexión
var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Chat')
    .build();

// indicamos a signalr que inicie, pasando como parametro el nombre del método y el código de la sala
connection.start().then(() => {
    connection.invoke("AddRoom", roomId);
}).catch(error => { console.error(error); });

document.getElementById("btnSend").addEventListener("click", (event) => {
    event.preventDefault();

    let user = document.getElementById("UserId").value;
    let message = document.getElementById("messageText").value;
    if (!message) return;

    // para enviar el mensaje indicamos a que método del hub queremos que llegue
    connection.invoke("SendMessage", roomId, user, message)
        .catch(error => { console.error(error); });

    // limpiamos la caja de texto
    document.getElementById("messageText").value = "";
    document.getElementById("messageText").focus();

    // recibimos el message
    connection.on("recieveMessage", (user, message) => {
        toastr["success"](message);
        let userChatDTO = {
            mensaje: message,
            UserId: user
        };
        //$.post("ChatTemplate", userChatDTO).then(result => {
        //    $("#chat").append(result);
        //});
    });

    event.preventDefault();

});

connection.on("ShowWho", (connector) => {
    toastr["success"](connector);
});