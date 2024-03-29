﻿var cultureInfo = '';

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
                $('#tablaRegistros tbody tr').remove();
                    activo = data.activo ? 'green' : 'red';
                    let tr = `<tr>
                      <td style='color: ${activo}'> ${data.id} </td>
                      <td style='color: ${activo}'> ${data.nombre} </td>
                      <td style='color: ${activo}'> ${data.dni} </td>
                      <td style='color: ${activo}'> ${data.direccion} </td>
                      <td style='color: ${activo}'> ${data.telefono} </td>
                      <td style='color: ${activo}'> ${data.email} </td>
                      <td style='color: ${activo}'> ${data.fechaEnvio.substring(0, 10)} </td>
                      <td style='color: ${activo}'> ${data.fechaLlegada.substring(0, 10)} </td>
                      <td style='color: ${activo}'> ${item.fechaReclamo.substring(0, 10)} </td>
                      <td style='color: ${activo}'> ${data.observacion} </td>
                    <td><a href="javascript:void(0)" class="btn btn-sm btn-warning" onclick="OpenModalEditar(${item.id},'${item.nombre}','${item.dni}','${item.direccion}','${item.telefono}','${item.email}','${item.fechaEnvio.substring(0, 10)}','${item.fechaLlegada.substring(0, 10)}','${item.fechaReclamo.substring(0, 10)}','${item.observacion}')">${editar}</a></td>
                     <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="Quitar(${data.id})">${eliminar}</a></td>
                      </tr>`;
                    $('#tablaRegistros tbody').append(tr);
                
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
                      <td style='color: ${activo}'> ${item.fechaReclamo.substring(0, 10)} </td>
                      <td style='color: ${activo}'> ${item.observacion} </td>
                     <td><a href="javascript:void(0)" class="btn btn-sm btn-warning" onclick="OpenModalEditar(${item.id},'${item.nombre}','${item.dni}','${item.direccion}','${item.telefono}','${item.email}','${item.fechaEnvio.substring(0, 10)}','${item.fechaLlegada.substring(0, 10)}','${item.fechaReclamo.substring(0, 10)}','${item.observacion}')">${editar}</a></td>
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

function OpenModalEditar(id, nombre, dni, direccion, telefono, email, fecha, fechaLlegada, fechaReclamo,observacion) {
    $("#_id").val(id);
    $('#_nombre').val(nombre);
    $('#_dni').val(dni);
    $('#_direccion').val(direccion);
    $('#_telefono').val(telefono);
    $('#_email').val(email);
    $('#_fecha').val(fecha);
    $('#_fechaLlegada').val(fechaLlegada);
    $('#_fechaReclamo').val(fechaReclamo);
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
    var fechaReclamo = $('#_fechaReclamo').val();
    var descripcion = $('#_descripcion').val();
    var msj = '';

    if (cultureInfo == 'en-US')
        msj = "All fields are required.";
    else if (cultureInfo == 'es-ES')
        msj = "Todos los campos son requeridos.";

    if (id === '' || nombre === '' || dni === '' || direccion === '' || telefono === '' ||
        email === '' || fecha === '' || fechaLlegada === '' || fechaReclamo === '' || descripcion === '') {
        toastr.warning(msj);
        return false;
    }

    var success = cultureInfo == 'en-US' ? 'Update success.' : 'Actualizacion exitosa.';
    var error = cultureInfo == 'en-US' ? 'Update failed.' : 'Error al actualizar.';

    $.ajax({
        type: "POST",
        url: urlUpdateTrazabilidad,
        data: {
            id: id, nombre: nombre, dni: dni, direccion: direccion, telefono: telefono,
            email: email, fechaEnvio: fecha, fechaLlegada: fechaLlegada, fechaReclamo: fechaReclamo, observacion: descripcion
        },
        datatype: "json",
        success: function (data) {
            if (data.estatus)
                toastr.success(success);
            else
                toastr.error(error); 

            setTimeout(1500, CloseModalEditar);
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
        data: { id: id },
        datatype: "json",
        success: function (data) {
            if (data.estatus)
                toastr.success(success);
            else
                toastr.error(error);         

        }
    });
    return false;
}




