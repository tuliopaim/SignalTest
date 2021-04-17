"use strict";

var connection;

$(function() {
    connection = new signalR.HubConnectionBuilder().withUrl("/hub/user").build();

    connection.on("UsuariosOnline", renderizarLista);
    
    connection.start().then(atualizarLista).catch(function (err) {
        return console.log(err.toString());
    });
    
    $("#estouOnline").on('click', estouOnline);

    $("#atualizarLista").on('click', atualizarLista);
});

function estouOnline(e) {
    e.preventDefault();

    connection.invoke("EstouAqui");
}

function atualizarLista(e) {
    if(e) e.preventDefault();

    connection.invoke("AtualizarInstanciasOnline");
}

function renderizarLista(lista) {
    let quantidadeOnline = lista.length;

    $("#quantity").html(quantidadeOnline);

    var listaUsers = $("#usersOnline");

    listaUsers.html('');

    for (let i = 0; i < quantidadeOnline; i++) {
        let user = lista[i];

        let li = '<li class="list-group-item"><b>' +
            user.nome + '</b> online às <b>' + user.vistoPorUltimoStr +
            '</b></li>';

        listaUsers.append(li);
    }
} 