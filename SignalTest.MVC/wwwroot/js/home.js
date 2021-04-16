"use strict";

var connection;

$(function() {
    connection = new signalR.HubConnectionBuilder().withUrl("/hub/instances").build();

    connection.on("InstanciasOnline", renderizarLista);

    connection.on("MeuId", SetarBoasVindas);

    connection.start().then(atualizarLista).catch(function (err) {
        return console.error(err.toString());
    });

    $("#criarRegistro").on('click', criarInstancia);

    $("#estouOnline").on('click', estouOnline);

    $("#atualizarLista").on('click', atualizarLista);
});

function SetarBoasVindas (user) {
    let boasVindas = 'Olá ' + user.nome + ', ';

    $("#criarRegistro").prop('disabled', true);

    $('#boasVindas').prepend(boasVindas);
    $("#userId").val(user.id);
}

function criarInstancia(e) {
    e.preventDefault();

    let nome = $("#nome").val();

    connection.invoke("SouNovoAqui", nome);
}

function estouOnline(e) {
    e.preventDefault();

    let userId = $("#userId").val();

    connection.invoke("EstouAqui", userId);
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

