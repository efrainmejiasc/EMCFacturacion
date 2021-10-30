
$(document).ready(function () {
    console.log("ready!");
    $('#stock_').hide();
    var date = FechaActual();
    $('#fechaInicio').val(date);
    $('#fechaFinal').val(date);
    GetStockTotal();
});

function FechaActual() {

    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    return date;
}

function GetStockTotal() {

    $.ajax({
        type: "GET",
        url: urlGetStockTotal,
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaStock tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> ${item.identificador.substring(1,8)} </td>
                      <td> ${item.nombreProducto} </td>
                      <td> ${item.unidad} </td>
                      <td> ${item.cantidad} </td>
                      </tr>`;
                    $('#tablaStock tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 2000);
            }
            else {
                $('#tablaStock tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaStock tbody tr').remove();
        }
    });

    $("#tablaStock").addClass("display compact dt-center");
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