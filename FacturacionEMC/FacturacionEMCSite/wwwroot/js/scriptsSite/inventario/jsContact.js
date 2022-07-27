var cultureInfo = '';

$(document).ready(function () {
    console.log('!ready');
    GetUsuarios();
    var date = FechaActual();
    $('#fechaInicio').val(date);
    $('#fechaFinal').val(date);

    cultureInfo = $('#cultureInfo').val();
});


function FechaActual() {

    var today = new Date();
    var year = today.getFullYear();
    var moth = (today.getMonth() + 1) <= 9 ? "0" + (today.getMonth() + 1) : (today.getMonth() + 1);
    var day = today.getDate() <= 9 ? "0" + today.getDate() : today.getDate();
    var date = year + '-' + moth + '-' + day;

    return date;
}


function GetUsuarios() {

    var Assignment = cultureInfo == 'en-US' ? 'Assignment' : 'Asignaciones';

    $.ajax({
        type: "GET",
        url: urlGetUsuarios,
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaUsuarios tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = '';
                    var est = item.activo ? 'Activo' : 'Inactivo';
                    var rol = item.idRol == 3 ? 'Seller' : item.idRol == 2 ? 'Client' : 'Manager';
                    if (!item.activo)
                        tr = `<tr>
                      <td style=color:red;> ${est} </td>
                      <td> ${item.nombre} </td>
                      <td> ${item.apellido} </td>
                      <td><input type="button" class="btn btn-sm btn-primary" onclick="GetAsignacionVendedor(${item.id} , ${item.idEmpresa})" value="${Assignment}" style="width:100px;"></td>
                      </tr>`;
                    else
                        tr = `<tr>
                      <td style=color:green;> ${est} </td>
                      <td> ${item.nombre} </td>
                      <td> ${item.apellido} </td>
                      <td><input type="button" class="btn btn-sm btn-primary" onclick="GetAsignacionVendedor(${item.id} , ${item.idEmpresa})" value="${Assignment}" style="width:100px;"></td>
                      </tr>`;

                    $('#tablaUsuarios tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
            }
            else {
                $('#tablaUsuarios tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaUsuarios tbody tr').remove();
        }
    });

    $("#tablaUsuarios").addClass("display compact dt-center");
    return false;
}


function InicializarDataTable() {
    var init = $('#initDataTable').val();

    try {
        if (init === 'no') {
            $('#tablaUsuarios').DataTable({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "pageLength": 50,
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
            $('#initDataTable').val('si');
        } else {
            $('#tablaUsuarios').DataTable().fnDestroy({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "pageLength": 50,
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
        }
    } catch { console.log(''); }

    $("#tablaUsuarios").addClass("display compact dt-center");
}


function GetAsignacionVendedor(id,idEmpresa) {

    $.ajax({
        type: "GET",
        url: urlGetStockTransitoVendedor,
        data: { idVendedor: id, idEmpresa: idEmpresa },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaAsignaciones tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> ${item.nombreVendedor} </td>
                      <td> ${item.identificador.substring(1, 8)} </td>
                      <td> ${item.nombreArticulo} </td>
                      <td> ${item.strUnidad} </td>
                      <td> ${item.cantidad} </td>
                      </tr>`;
                    $('#tablaAsignaciones tbody').append(tr);
                });
                $('#modalAsignaciones').show();
            }
            else {
                $('#tablaAsignaciones tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaAsignaciones tbody tr').remove();
        }
    });

    $("#tablaAsignaciones").addClass("display compact dt-center");

    return false;
}

function OcultarModalAsignaciones() {
    $('#modalAsignaciones').hide();
}



