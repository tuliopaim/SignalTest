"use strict";

$(function() {
    var connection = new signalR.HubConnectionBuilder().withUrl("/hub/instances").build();

    $("#estouOnline").on('click', function (e) {
        debugger;

        e.preventDefault();
        
        var userId = $("#userId").val();

        connection.invoke("EstouAqui", userId);
    });

    connection.on("InstanciasOnline", function (lista) {
        renderizarLista(lista);
    });

    connection.on("MeuId", function (id) {
        debugger;

        $("#userId").val(id);
    });

    connection.start().then(function () {

        connection.invoke("SouNovoAqui");

    }).catch(function (err) {
        return console.error(err.toString());
    });
    

});

function renderizarLista(lista) {
    let quantidadeOnline = lista.length;

    $("#quantity").html(quantidadeOnline);

    var listaUsers = $("#usersOnline");

    listaUsers.html('');

    for (let i = 0; i < quantidadeOnline; i++) {
        let user = lista[i];

        let li = '<li class="list-group-item"><b>' +
            user.id + '</b> online às <b>' + user.vistoPorUltimoStr +
            '</b></li>';

        listaUsers.append(li);
    }
}


