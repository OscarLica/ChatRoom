$(document).ready(() => {
   
    $(document).on("click", "a[data-chat-room]", function () {
        let roomId = $(this).data("chatRoom");
        let user = $(this).data("chatUser");

        $.get("/Chat/ChatRooms/" + roomId).then(response => {
            $(".mesgs").empty();
            $(".mesgs").append(response);

            let name = $("#ChatRoomName").val();
            $("#chatName").text(name);
            var hubModul = Module.get("hub");
            hubModul.initConnection();
            hubModul.addEventSend();
        });

        //window.location.href = "/Chat/ChatRooms/" + roomId;
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
            toastr["success"]("Chat room created succesfully")
            $("#chat-room-modal").modal("hide");
        });
    });

});