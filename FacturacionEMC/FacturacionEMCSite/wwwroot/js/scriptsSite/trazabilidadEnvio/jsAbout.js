var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    var date = FechaActual();
    $('#fechaInicio').val(date);
    $('#fechaFinal').val(date);
}


function FechaActual() {

    var today = new Date();
    var year = today.getFullYear();
    var moth = (today.getMonth() + 1) <= 9 ? "0" + (today.getMonth() + 1) : (today.getMonth() + 1);
    var day = today.getDate() <= 9 ? "0" + today.getDate() : today.getDate();
    var date = year + '-' + moth + '-' + day;

    return date;
}


function ObtenerTrazabilidadesEnvios() {
    var fechaInicial = $('#fechaInicio').val();
    var fechaFinal = $('#fechaFinal').val();

    if (fechaInicial === '' || fechaFinal === '') {
        if (cultureInfo == 'en-US')
            toastr.warning("All fields are required.");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Todos los campos son requeridos.");

        return false;
    }

    $.ajax({
        type: "GET",
        url: urlObtenerTrazabilidadesEnvios,
        data: { fInicial: fechaInicial, fFinal:fechaFinal },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                console.log(data); 
            }
        }
    });

    return false;
}

