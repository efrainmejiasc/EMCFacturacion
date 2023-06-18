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
                     <td><a href="javascript:void(0)" class="btn btn-sm btn-warning" onclick="OpenModalEditar(${item.id},'${item.nombre}','${item.dni}','${item.direccion}','${item.telefono}','${item.email}','${item.fechaEnvio.substring(0, 10)}','${item.fechaLlegada.substring(0, 10)}','${item.observacion}')">${editar}</a></td>
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

function OpenModalEditar(id,nombre,dni,direccion,telefono,email,fecha,fechaLlegada,observacion) {
    $("#_id").val(id);
    $('#_nombre').val(nombre);
    $('#_dni').val(dni);
    $('#_direccion').val(direccion);
    $('#_telefono').val(telefono);
    $('#_email').val(email);
    $('#_fecha').val(fecha);
    $('#_fechaLlegada').val(fechaLlegada);
    $('#_descripcion').val(observacion);

    $("#modalEditar").show();
}

function CloseModalEditar(id) {
    $("#modalEditar").hide();

}

function Editar() {

    var id = $("#_id").val();
    var nombre = $('#_nombre').val();
    var dni = $('#_dni').val();
    var direccion = $('#_direccion').val();
    var telefono = $('#_telefono').val();
    var email = $('#_email').val();
    var fecha = $('#_fecha').val();
    var fechaLlegada = $('#_fechaLlegada').val();
    var descripcion = $('#_descripcion').val();
    var msj = '';

    if (cultureInfo == 'en-US')
        msj = "All fields are required.";
    else if (cultureInfo == 'es-ES')
      msj = "Todos los campos son requeridos.";

    if (id === '' || nombre === '' || dni === '' || direccion === '' || telefono === '' ||
        email === '' || fecha === '' || fechaLlegada === '' || descripcion === '') {
        toastr.warning(msj);
        return false;
    }

    var success = cultureInfo == 'en-US' ? 'Update success.' : 'Actualizacion exitosa.';
    var error = cultureInfo == 'en-US' ? 'Update failed.' : 'Error al actualizar.';

    $.ajax({
        type: "POST",
        url: urlUpdateTrazabilidad,
        data: { id: id, nombre: nombre, dni: dni, direccion: direccion, telefono: telefono,
            email: email, fechaEnvio: fecha, fechaLlegada: fechaLlegada, observacion: descripcion },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                console.log(data);
                toaster.success(success);
            }
            else {
                toaster.warning(error);
            }
        }
    });
    return false;
}

function Eliminar(id) {

    var success = cultureInfo == 'en-US' ? 'Removed success.' : 'Eliminacion exitosa.';
    var error = cultureInfo == 'en-US' ? 'Removed failed.' : 'Error al eliminar.';

    $.ajax({
        type: "POST",
        url: urlEliminarTrazabilidad,
        data: { id: id},
        datatype: "json",
        success: function (data) {
            if (data != null) {
                console.log(data);
                toaster.success(success);
            }
            else {
                toaster.warning(error);
            }
        }
    });
    return false;
}


