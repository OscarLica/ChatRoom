$(document).ready(() => {
    /** Id de la sala de chat */
    var chatRoomId = $("#ChatRoomId").val();

     /* si existe una sala de chat activa inicializamos signalR con la sala de chat*/
    if (chatRoomId) {
        var hubModul = Module.get("hub");
        hubModul.initConnection(chatRoomId);
        hubModul.addEventSend();
        $('.msg_history').scrollTop($('.msg_history')[0].scrollHeight);
    }

    $(document).on("click", "a[data-chat-room]", function () {
        let roomId = $(this).data("chatRoom");
        window.location.href = "/Chat/" + roomId;
    });

    $(document).on("click", "button[data-new-chat-room]", function () {

        $.get("/ChatRoom/Formulario").then(response => {
            $("#chat-room-modal").html(response).modal("show");
            let formValidation = Module.get("form-validation");
            formValidation.InitValidation("#frm-chat-room");
        });
    });

    $(document).on("submit", "#frm-chat-room", function (event) {
        event.preventDefault();

        let formValidation = Module.get("form-validation");
        let chatroom = formValidation.GetDataForm("data-name", "name");

        $.post("/ChatRoom/Formulario", chatroom).then((response) => {
            $("#chat-room-modal").modal("hide");
            toastr["success"]("Chat room created succesfully");
            window.location.reload();
        });
    });

});