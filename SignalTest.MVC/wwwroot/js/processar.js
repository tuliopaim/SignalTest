﻿var connection;

$(function () {
    connection = new signalR.HubConnectionBuilder().withUrl("/hub/processamento").build();

    connection.on("ReportProcessamento", renderizarReport);
    
    connection.start().catch(function (err) {
        return console.log(err.toString());
    });

    $("#processar").on('click', processar);
});


function processar(e) {
    e.preventDefault();

    connection.invoke("Processar");
}

function renderizarReport(itemProcessado, percentual) {
    let itensProcessados = $("#itensProcessados");

    let li = '<li class="list-group-item">' +
        itemProcessado + ' - ' + percentual + ' %' +
        '</li>';

    itensProcessados.append(li);
}