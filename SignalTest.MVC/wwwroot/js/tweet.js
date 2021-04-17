"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hub/tweet").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveTweet", function (tweet) {
    let listaDeMensagens = $("#messagesList");
    
    let htmlMsg = "<b>" + tweet.nomeUsuario + ":</b> " + tweet.mensagem;
    htmlMsg += ' - <span class="data-tweet"> ' + tweet.dataStr + '</span>';

    var li = '<li class="list-group-item">' + htmlMsg + '</li>';

    listaDeMensagens.append(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.log(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = $("#messageInput").val();
    
    connection.invoke("SendTweet", message).catch(function (err) {
        return console.log(err.toString());
    });

    event.preventDefault();
});