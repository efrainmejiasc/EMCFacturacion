var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    cultureInfo = $('#cultureInfo').val();
    $('#stock_').hide();
    var date = FechaActual();
    $('#fechaInicio').val(date);
    $('#fechaFinal').val(date);
    GetStockTotal();
});

function FechaActual() {

    var today = new Date();
    var year = today.getFullYear();
    var moth = (today.getMonth() + 1) <= 9 ? "0" + (today.getMonth() + 1) : (today.getMonth() + 1);
    var day = today.getDate() <= 9 ? "0" + today.getDate() : today.getDate();
    var date = year + '-' + moth + '-' + day;

    return date;
}

function GetStockTotal() {

    var Transit = cultureInfo == 'en-US' ? 'Transit' : 'Transito';

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
                       <td><input type="button" class="btn btn-sm btn-primary" onclick="Transito(${item.idArticulo})" value="${Transit}" style="width:100px;" ></td>
                      </tr>`;
                    $('#tablaStock tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
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
            $('#tablaStock').DataTable({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
            $('#initDataTable').val('si');
        } else {
            $('#tablaStock').DataTable().fnDestroy({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
        }
    } catch { console.log(''); }

    $("#tablaStock").addClass("display compact dt-center");
}

function Transito(idProducto) {

    $.ajax({
        type: "GET",
        url: urlGetStockTransitoProducto,
        data: { idProducto: idProducto },
        datatype: "json",
        success: function (data)
        {
            if (data != null) {
                $('#tablaTransito tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> ${item.identificador.substring(1, 8)} </td>
                      <td> ${item.nombreVendedor} </td>
                      <td> ${item.nombreArticulo} </td>
                      <td> ${item.strUnidad} </td>
                      <td> ${item.cantidad} </td>
                      </tr>`;
                    $('#tablaTransito tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
                $('#modalTransito').show();
            }
            else {
                $('#tablaTransito tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaTransito tbody tr').remove();
        }
      
    });

    $("#tablaTransito").addClass("display compact dt-center");

    return false;
}

function OcultarModalTransito() {
    $('#modalTransito').hide();
}