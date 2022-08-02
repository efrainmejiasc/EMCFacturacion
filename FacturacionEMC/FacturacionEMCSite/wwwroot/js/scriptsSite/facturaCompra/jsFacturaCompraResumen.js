var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});


function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    $('#rCompra_').hide();
    var date = FechaActual();
    $('#fechaInicio').val(date);
    $('#fechaFinal').val(date);
    GetFacturas();
}


function FechaActual() {

    var today = new Date();
    var year = today.getFullYear();
    var moth = (today.getMonth() + 1) <= 9 ? "0" + (today.getMonth() + 1) : (today.getMonth() + 1);
    var day = today.getDate() <= 9 ? "0" + today.getDate() : today.getDate();
    var date = year + '-' + moth + '-' + day;

    return date;
}

function GetFacturas() {

    $.ajax({
        type: "GET",
        url: urlGetFacturas,
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaFacturas tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> <a href="javascript:void(0);" onclick="MostrarDetalle('${item.numeroFactura}');">${item.numeroFactura}</a></td>
                      <td> ${item.fecha.substring(0, 10)} </td>
                      <td> ${item.nombreProveedor} </td>
                      <td> ${item.rfc} </td>
                      <td> ${item.metodoPago} </td>
                      <td> ${item.subtotal} </td>
                      <td> ${item.descuento} </td>
                      <td> ${item.impuesto} </td>
                      <td> ${item.total} </td>
                      </tr>`;
                    $('#tablaFacturas tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
            }
            else
            {
                $('#tablaFacturas tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaFacturas tbody tr').remove();
        }
    });

    $("#tablaFacturas").addClass("display compact dt-center");

    return false;
}

function GetFacturasFechas() {
    var fechaInicio= $('#fechaInicio').val();
    var fechaFinal = $('#fechaFinal').val();
    $.ajax({
        type: "GET",
        url: urlGetFacturasFechas,
        data: { fechaInicial: fechaInicio, fechaFinal: fechaFinal },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaFacturas tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> <a href="javascript:void(0);" onclick="MostrarDetalle('${item.numeroFactura}');">${item.numeroFactura}</a></td>
                      <td> ${item.fecha.substring(0,10)} </td>
                      <td> ${item.nombreProveedor} </td>
                      <td> ${item.rfc} </td>
                      <td> ${item.metodoPago} </td>
                      <td> ${item.subtotal} </td>
                      <td> ${item.descuento} </td>
                      <td> ${item.impuesto} </td>
                      <td> ${item.total} </td>
                      </tr>`;
                    $('#tablaFacturas tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 2000);
            }
            else
            {
                $('#tablaFacturas tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaFacturas tbody tr').remove();
        }
    });

    $("#tablaFacturas").addClass("display compact dt-center");
    setTimeout(InicializarDataTable, 1000);
    return false;
}

function InicializarDataTable() {
    var init = $('#initDataTable').val();

    try {
        if (init === 'no') {
            $('#tablaFacturas').DataTable({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
            $('#initDataTable').val('si');
        } else {
            $('#tablaFacturas').DataTable().fnDestroy({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
        }
    } catch { console.log(''); }

    $("#tablaFacturas").addClass("display compact dt-center");
}

function MostrarDetalle(numeroFactura) {
    $('#modalDetalle').show();
    GetFacturaDetalle(numeroFactura);
}

function OcultarModalDetalle() {
    $('#modalDetalle').hide();
}


function GetFacturaDetalle(numeroFactura) {

    $.ajax({
        type: "GET",
        url: urlGetFacturaDetalle,
        data: { numeroFactura: numeroFactura },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaDetalle tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> ${item.linea} </td>
                      <td style="width: 99%"> ${item.nombreArticulo} </td>
                      <td> ${item.unidadMedida} </td>
                      <td> ${item.cantidad} </td>
                      <td> ${item.precioUnitario} </td>
                      <td> ${item.subtotal} </td>
                      <td> ${item.descuento} </td>
                      <td> ${item.impuesto} </td>
                      <td> ${item.total} </td>
                      </tr>`;
                    $('#tablaDetalle tbody').append(tr);
                });
            }
            else {
                $('#tablaDetalle tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaDetalle tbody tr').remove();
        }
    });

    $("#tablaDetalle").addClass("display compact dt-center");
    return false;
}