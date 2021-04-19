var connection;

$(function () {
    connection = new signalR.HubConnectionBuilder().withUrl("/hub/processamento").build();

    $('#processar').prop('disabled', true);

    connection.on("ResultadoProcessamento", renderizarReport);
    
    connection.start().then(function() {
        $('#processar').prop('disabled', false);
    }).catch(function (err) {
        return console.log(err.toString());
    });

    $("#processar").on('click', processar);
});


function processar(e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: 'Processamento/Processar'
    });
}

function renderizarReport(itemProcessado, percentual) {
    let itensProcessados = $("#itensProcessados");

    let li = '<li class="list-group-item">' +
        itemProcessado + ' - ' + percentual + ' %' +
        '</li>';

    itensProcessados.append(li);
}