

var activeRoomId = "";

// اتصال با هاب کانکشن پشتیبانی یا فروشنده

var supportConnection = new signalR.HubConnectionBuilder()
    .withUrl("/supporthub")
    .build();


//ایجاد یک کانکشن با سرور سیگنال آر

var chatConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();


function Init() {
    supportConnection.start();
    chatConnection.start();


    var answerMessageForm = $("#AnswerMessageForm");
    answerMessageForm.on('submit', function (e) {
        e.preventDefault();

        var text = e.target[0].value;
        e.target[0].value = '';
        SupportSendMessage(text);

    });
};


function SupportSendMessage(text) {
    if (text) {
        supportConnection.invoke("SupportSendMessage", activeRoomId, text);
    }
}

chatConnection.on("getNewMessage", showMessage);

$(document).ready(function () {
    Init();
    roomMessageEl.style.display = 'none';

});




supportConnection.on("getNewMessage", addMessage);

function addMessage(messages) {
    if (!messages) {
        return;
    }

    messages.forEach(function (m) {
        showMessage(m.sender, m.message, m.time);
    });
}

function showMessage(sender, message, time) {
    time = new Date().toLocaleDateString('fa-IR');
    $("#chatMessage").append(`<div class="msg right-msg">
                               <div class="msg-bubble">
                               <div class="msg-info">
                               <div class="msg-info-name">${sender}</div>
                               </div
                               <div class="msg-text">
                               ${message}
                               <br/>
                               <span class="msg-info-time">${time}</span>
                               </div>
                               </div>
                               </div>`);


}

// دریافت لیست چت روم ها
supportConnection.on("GetRooms", loadRooms);


var roomListEl = document.getElementById("roomList");
var roomMessageEl = document.getElementById("chatMessage");

function loadRooms(rooms) {
    if (!rooms) {
        return;
    }

    var roomIds = Object.keys(rooms);
    if (!roomIds.length) {
        return;
    }

    removeAllChildren(roomListEl);

    roomIds.forEach(function (id) {
        var roomInfo = rooms[id];
        if (!roomInfo) {
            return $("#roomList").append(`<div class="col-sm-12 col-md-12 col-lg-12">
                                      <table class="table table-bordered table-striped  text-center">
                                      <thead class="thead-dark">
                                      <tr>
                                      <th>هشدار !</th>
                                      </tr>
                                      </thead>
                                      <tbody>
                                      <tr>
                                      <td class="text-warning">هیج گفتگویی برای شما وجود ندارد.</td>
                                      </td>
                                      </tr>
                                      </tbody>
                                      </table>
                                      </div>`);
        }

        //ایجاد دکمه برای لیست

        return $("#roomList").append(`<div class="col-sm-12 col-md-12 col-lg-12">
                                      <table class="table table-bordered table-striped  text-center">
                                      <thead class="thead-dark">
                                      <tr>
                                      <th>شناسه گفتگو</th>
                                      <th>عملیات</th>
                                      </tr>
                                      </thead>
                                      <tbody>
                                      <tr>
                                      <td>${roomInfo}</td>
                                      <td>
                                      <div class="btn-group btn-group-lg" role="group" aria-label="Basic mixed styles example">
                                      <a class="list-group-item btn btn-warning btn-sm text-dark" data-id="${roomInfo}">ارسال پاسخ به کاربر</a>
                                      </div>
                                      </td>
                                      </tr>
                                      </tbody>
                                      </table>
                                      </div>`);

    });

}


function removeAllChildren(node) {
    if (!node) {
        return;
    }

    while (node.lastChild) {
        node.removeChild(node.lastChild);
    }
}

function setActiveRoomButton(el) {
    var allButtons = roomListEl.querySelectorAll("a.list-group-item");

    allButtons.forEach(function (btn) {
        btn.classList.remove('active');
    });

    el.classList.add('active');
}

function switchActiveRoom(id) {
    if (id === activeRoomId) {
        return;
    }

    removeAllChildren(roomMessageEl);

    if (activeRoomId) {
        chatConnection.invoke("LeaveRoom", activeRoomId);
    }

    activeRoomId = parseInt(id);

    chatConnection.invoke("JoinRoom", activeRoomId);
    supportConnection.invoke('LoadMessage', activeRoomId);

}


roomListEl.addEventListener('click', function (e) {
    setActiveRoomButton(e.target);
    roomMessageEl.style.display = 'block';
    var roomId = e.target.getAttribute("data-id");

    switchActiveRoom(roomId);
});