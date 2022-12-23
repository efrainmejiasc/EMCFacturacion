var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});


function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    console.log(cultureInfo);
}

function BuscarProducto() {

    var strProducto = $('#strBusqueda').val();

    if (strProducto == '')
        return false;

    $.ajax({
        url: urlGetInfoProducto,
        data: {strProducto: strProducto},
        type: "GET",
        timeout: 0,
        success: function (data) {
            if (data != null) {
                console.log(data);
            }
            else {
                var messaje = cultureInfo === 'es-ES' ? "Transaccion fallida" : "Failure transaction";
                toastr.error(messaje);
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            toastr.error('ERROR INESPERADO: ' + textStatus + ' ' + jqXHR + ' ' + errorThrown);
        }
    });

    return false;
}