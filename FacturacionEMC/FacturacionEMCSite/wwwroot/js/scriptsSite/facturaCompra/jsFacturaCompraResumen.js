$(document).ready(function () {
    console.log("ready!");
    $('#rCompra_').hide();
    var date = FechaActual();
    $('#fechaInicio').val(date);
    $('#fechaFinal').val(date);

    GetFacturas();
});

function FechaActual() {

    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
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
                      <td> ${item.numeroFactura} </td>
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
                      <td> ${item.numeroFactura} </td>
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
    setTimeout(InicializarDataTable, 2000);
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