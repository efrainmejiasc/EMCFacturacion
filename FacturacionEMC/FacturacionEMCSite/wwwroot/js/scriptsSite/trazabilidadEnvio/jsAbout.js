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

    var activo = '';
    var eliminar = cultureInfo == 'en-US' ? 'Remove' : 'Eliminar';
    var editar = cultureInfo == 'en-US' ? 'Edit' : 'Editar';

    $.ajax({
        type: "GET",
        url: urlObtenerTrazabilidadesEnvios,
        data: { fInicial: fechaInicial, fFinal:fechaFinal },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaRegistros tbody tr').remove();
                $.each(data, function (index, item) {
                    activo = item.activo ? 'green' : 'red';
                    let tr = `<tr>
                      <td style='color: ${activo}'> ${item.id} </td>
                      <td style='color: ${activo}'> ${item.nombre} </td>
                      <td style='color: ${activo}'> ${item.dni} </td>
                      <td style='color: ${activo}'> ${item.direccion} </td>
                      <td style='color: ${activo}'> ${item.telefono} </td>
                      <td style='color: ${activo}'> ${item.email} </td>
                      <td style='color: ${activo}'> ${item.fechaEnvio.substring(0, 10)} </td>
                      <td style='color: ${activo}'> ${item.fechaLlegada.substring(0, 10)} </td>
                      <td style='color: ${activo}'> ${item.observacion} </td>
                     <td><a href="javascript:void(0)" class="btn btn-sm btn-warning" onclick="Editar(${item.id})">${editar}</a></td>
                     <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="Quitar(${item.id})">${eliminar}</a></td>
                      </tr>`;
                    $('#tablaRegistros tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
            }
            else {
                $('#tablaRegistros tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaRegistros tbody tr').remove();
        }
    });

    $("#tablaRegistros").addClass("display compact dt-center");
    return false;
}

function InicializarDataTable() {
    var init = $('#initDataTable').val();

    try {
        if (init === 'no') {
            $('#tablaRegistros').DataTable({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
            $('#initDataTable').val('si');
        } else {
            $('#tablaRegistros').DataTable().fnDestroy({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
        }
    } catch { console.log(''); }

    $("#tablaRegistros").addClass("display compact dt-center");
}

