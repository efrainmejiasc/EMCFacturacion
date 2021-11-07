$(document).ready(function () {
    console.log("ready!");
    $('#usuario_').hide();
    $('#fVenta_').hide();
    $('#fCompra_').hide();
    $('#rVenta_').hide();
    $('#rCompra_').hide();
    $('#stock_').hide();
    $('#inicioFact_').hide();
    GetUsuarioLogger();
    MostrarModalInstrucciones();
});


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
                toastr.warning("Does not have privileges to initiate billing.");
            }
        }
    });
    return false;
}

function SetInicioFaturacion() {

    var numeroFactura = $('#numeroFactura').val();
    if (numeroFactura === '') {
        toastr.warning("All fiels required.");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlSetInicioFacturacion,
        data: { numeroFactura: numeroFactura},
        datatype: "json",
        success: function (data) {
            if (data.estatus) 
                toastr.success("Successful transaction.");
            else
                toastr.warning("Transaction error.");
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
            if (data.estatus)
                toastr.success("Successful transaction.");
            else
                toastr.warning("Transaction error.");
        }
    });
    return false;
}

function ValidarDecimal() {
    var numeroFactura = $('#numeroFactura').val();

    if (numeroFactura.includes(',') || numeroFactura.includes('.')) {
        toastr.warning("The number must be integer.");
        return false;
    }
}

function MostrarModalInstrucciones() {
    $('#modalInstrucciones').show();
}

function OcultarModalInstrucciones() {
    $('#modalInstrucciones').hide();
}