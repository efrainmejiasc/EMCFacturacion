var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
}

function ObtenerTrazabilidadEnvio() {
    $('#dni').val('');
    var guid = $('#guid').val();
    if (guid === '') {
        if (cultureInfo == 'en-US')
            toastr.warning("The field identifier is required.");
        else if (cultureInfo == 'es-ES')
            toastr.warning("El campo identificador es requerido.");

        return false;
    }

    $.ajax({
        type: "GET",
        url: urlObtenerTrazabilidadEnvio,
        data: { guid: guid },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                console.log(data);
            }
        }
    });

    return false;
}

function ObtenerTrazabilidadesEnvio() {
    $('#guid').val('');
    var dni = $('#dni').val();
    if (dni === '') {
        if (cultureInfo == 'en-US')
            toastr.warning("The field document id is required.");
        else if (cultureInfo == 'es-ES')
            toastr.warning("El campo documento id es requerido.");

        return false;
    }

    $.ajax({
        type: "GET",
        url: urlObtenerTrazabilidadesEnvio,
        data: { dni: dni },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                console.log(data);
            }
        }
    });

    return false;
}

