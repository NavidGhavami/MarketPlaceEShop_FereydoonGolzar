
var chatBox = $("ChatBox");

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.start();


//connection.invoke("SendNewMessage", "بازدید کننده", "این پیام از سمت کلاینت ارسال شده است");



// نمایش چت باکس برای کاربر


function Init() {
    setTimeout(2000);

    var newMessageForm = $("#NewMessageForm");
    newMessageForm.on("submit", function (e) {
        e.preventDefault();

        var message = e.target[0].value;
        e.target[0].value = '';
        SendMessage(message);

    });
}


function SendMessage(text) {
    connection.invoke("SendNewMessage", text);
}


// دریافت پیام از سرور

connection.on('getNewMessage', getMessage);

function getMessage(sender, message, warningMessage, time) {
    time = new Date().toLocaleDateString('fa-IR');
    $("#ChatBoxMessage").append(`<div class='msg left-msg'>
                                <div class='msg-bubble'>
                                <div class='msg-info'>
                                <div class='msg-info-name'>${sender}</div>
                                </div>
                                <div class='msg-text'>${message}</div>
                                <br/>
                                <div class='msg-text text-right text-danger'><strong>${warningMessage}<strong/></div>
                                <div class='msg-info-time'>${time}</div>
                                </div>
                                </div>`);
}

$(document).ready(function () {
    Init();
});