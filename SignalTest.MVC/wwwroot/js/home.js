"use strict";

var connection;

$(function() {
    connection = new signalR.HubConnectionBuilder().withUrl("/hub/user").build();

    $("#estouOnline").prop('disabled', true);

    connection.on("UsuariosOnline", renderizarLista);
    
    connection.start().then(function() {
        $("#estouOnline").prop('disabled', false);
    }).catch(function (err) {
        return console.log(err.toString());
    });
    
    $("#estouOnline").on('click', estouOnline);
});

function estouOnline(e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Home/EstouAqui"
    });
}

function renderizarLista(lista) {
    let quantidadeOnline = lista.length;

    $("#quantity").html(quantidadeOnline);

    $("#usersOnline").html('');

    for (let i = 0; i < quantidadeOnline; i++) {
        let user = lista[i];

        renderizarUsuario(user);
    }
} 

function renderizarUsuario(user) {
    let li = '<li class="list-group-item">' +
        '<b>' + user.nome + '</b> online às <b>' + user.vistoPorUltimoStr + '</b>' +
        '</li>';

    $("#usersOnline").prepend(li);
}