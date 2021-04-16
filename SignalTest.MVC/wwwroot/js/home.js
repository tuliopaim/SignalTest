"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hub/chat").build();

connection.on("HeIsHere", function (user, message) {
    debugger;

    let quantity = $("#quantity");

    let pessoasOnline = parseInt(quantity.html(), 10);
    pessoasOnline++;

    quantity.html(pessoasOnline);
});

connection.start().then(function () {

    connection.invoke("ImHere");

}).catch(function (err) {
    return console.error(err.toString());
});