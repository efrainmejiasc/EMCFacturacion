var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    $('#usuario_').hide();
    $('#fVenta_').hide();
    $('#fCompra_').hide();
    $('#rVenta_').hide();
    $('#rCompra_').hide();
    $('#stock_').hide();
    $('#inicioFact_').hide();
    GetUsuarioLogger();
    MostrarModalInstrucciones();
}


function GetUsuarioLogger() {

    $.ajax({
        type: "GET",
        url: urlUsuarioLogger,
        datatype: "json",
        success: function (data) {
            if (data.idRol == 2 || data == 3) {
                $("#numeroFactura").prop("disabled", true);
                $("#btnSet").prop("disabled", true);
                $("#btnRe").prop("disabled", true);
                if (cultureInfo == 'en-US')
                    toastr.warning("Does not have privileges to initiate billing.");
                else if (cultureInfo == 'es-ES')
                    toastr.warning("Np tienes privilegios para iniciar la facturacion.");
            }
        }
    });
    return false;
}

function SetInicioFaturacion() {

    var numeroFactura = $('#numeroFactura').val();
    if (numeroFactura === '') {
        if (cultureInfo == 'en-US')
            toastr.warning("All fields are required");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Todos los campos son requeridos");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlSetInicioFacturacion,
        data: { numeroFactura: numeroFactura},
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                if (cultureInfo == 'en-US')
                    toastr.success("Successful transaction.");
                else if (cultureInfo == 'es-ES')
                    toastr.success("Transaccion exitosa.");
            }
            else{
                if (cultureInfo == 'en-US')
                    toastr.warning("Transaction error.");
                else if (cultureInfo == 'es-ES')
                    toastr.warning("Error en transaccion.");
            }

        }
    });
    return false;
}

function ReInicioFacturacion() {

    $.ajax({
        type: "POST",
        url: urlReInicioFacturacion,
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                if (cultureInfo == 'en-US')
                    toastr.success("Successful transaction.");
                else if (cultureInfo == 'es-ES')
                    toastr.success("Transaccion exitosa.");
            }
            else {
                if (cultureInfo == 'en-US')
                    toastr.warning("Transaction error.");
                else if (cultureInfo == 'es-ES')
                    toastr.warning("Error en transaccion.");
            }
        }
    });
    return false;
}

function ValidarDecimal() {
    var numeroFactura = $('#numeroFactura').val();

    if (numeroFactura.includes(',') || numeroFactura.includes('.')) {
        if (cultureInfo == 'en-US')
            toastr.warning("The number must be integer.");
        else if (cultureInfo == 'es-ES')
            toastr.warning("El numero debe ser un entero.");
        return false;
    }
}

function MostrarModalInstrucciones() {
    $('#modalInstrucciones').show();
}

function OcultarModalInstrucciones() {
    $('#modalInstrucciones').hide();
}