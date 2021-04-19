"use strict";

var connection;

$(function() {
    connection = new signalR.HubConnectionBuilder().withUrl("/hub/tweet").build();
    
    $("#sendButton").prop('disabled', true);

    connection.on("NovoTweet", renderizarNovoTweet);

    connection.start().then(function () {
        $("#sendButton").prop('disabled', false);
    }).catch(function (err) {
        return console.log(err.toString());
    });

    $("#sendButton").on('click', novoTweet);

});

function renderizarNovoTweet(tweet) {
    let listaDeMensagens = $("#messagesList");

    let htmlMsg = "<b>" +
        tweet.nomeUsuario +
        "</b><br /> " +
        tweet.mensagem +
        "<br />" +
        '<span class="data-tweet">' +
        tweet.dataStr +
        '</span>';

    var li = '<li class="list-group-item">' + htmlMsg + '</li>';

    listaDeMensagens.prepend(li);
}

function novoTweet(e) {
    e.preventDefault();

    let mensagem = $("#messageInput").val();

    $.ajax({
        type: "POST",
        url: "/Tweet/NovoTweet?mensagem=" + mensagem,
        body: mensagem
    });
}