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
    var activo = '';
    var eliminar = cultureInfo == 'en-US' ? 'Remove' : 'Eliminar';
    var editar = cultureInfo == 'en-US' ? 'Edit' : 'Editar';

    $.ajax({
        type: "GET",
        url: urlObtenerTrazabilidadEnvio,
        data: { guid: guid },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                console.log(data);
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
    var activo = '';
    var eliminar = cultureInfo == 'en-US' ? 'Remove' : 'Eliminar';
    var editar = cultureInfo == 'en-US' ? 'Edit' : 'Editar';

    $.ajax({
        type: "GET",
        url: urlObtenerTrazabilidadesEnvio,
        data: { dni: dni },
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

