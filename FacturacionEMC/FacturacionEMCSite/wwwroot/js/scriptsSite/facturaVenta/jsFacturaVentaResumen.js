$(document).ready(function () {
    console.log("ready!");

    var date = FechaActual();
    $('#fechaInicio').val(date);
    $('#fechaFinal').val(date);
});

function FechaActual() {

    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    return date;
}