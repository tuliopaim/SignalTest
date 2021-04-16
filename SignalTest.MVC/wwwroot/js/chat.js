"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hub/chat").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    let htmlMsg = "<b>" + user + ":</b> " + message;

    var li = '<li class="list-group-item">' + htmlMsg + '</li>';

    $("#messagesList").append(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.log(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {

    var user = $("#userInput").val();
    var message = $("#messageInput").val();
    
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.log(err.toString());
    });

    event.preventDefault();
});