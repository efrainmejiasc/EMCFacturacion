var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    console.log(cultureInfo);
    $('#fechaLlegada').val(FechaActual());
}

function FechaActual() {
    var today = new Date();
    var date = '';
    var fecha3 = new Date();
    fecha3.setDate(today.getDate() + 3);
    date = fecha3.getFullYear() + '-' + (fecha3.getMonth() + 1) + '-' + fecha3.getDate();
    return ComplementoFecha(date);
}

function ComplementoFecha(date) {

    var partes = date.split('-')
    var fecha = '';
    var dia = '';
    var mes = parseInt(partes[1]) > 9 ? partes[1] : '0' + partes[1];
    dia = parseInt(partes[2]) > 9 ? partes[2] : '0' + partes[2];
    fecha = partes[0] + '-' + mes + '-' + dia;
    return fecha;
}

function GuardarTrazabilidadEnvio() {
    var nombre = $('#nombreCompleto').val();
    var dni = $('#dni').val();
    var direccion = $('#direccion').val();
    var telefono = $('#telefono').val();
    var email = $('#email').val();
    var fechaLlegada = $('#fechaLlegada').val();
    var observacion = $('#observacion').val();

    var mensaje = cultureInfo == 'en-US' ? 'All fields are required.' : 'Todos los campos son requeridos.';
    var valemail = cultureInfo == 'en-US' ? 'The email not is valid.' : 'El email no es valido.';
    if (nombre === '' || dni === '' || direccion === '' || telefono === '' ||
        email === '' || fechaLlegada === '' || observacion === '') {
        toastr.warning(mensaje);
        return false;
    }
    else if (!EmailValido(email)) {
        toastr.warning(valemail);
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlGuardarTrazabilidadEnvio,
        data: {
            nombre: nombre, dni: dni, direccion: direccion, telefono: telefono,
            email: email, fechaLlegada: fechaLlegada, descripcion: observacion
        },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                if (cultureInfo == 'en-US')
                    toastr.success("Traceability saved successfully.");
                else if (cultureInfo == 'es-ES')
                    toastr.success("Trazabilidad guardada correctamente.");

                setTimeout(LimpiarForm, 4000);
            }
            else {
                if (cultureInfo == 'en-US')
                    toastr.error("Unexpected error");
                else if (cultureInfo == 'es-ES')
                    toastr.error("Error inesperado");
            }
        }
    });

    return false;
}

function EmailValido(mail) {
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
}

function  LimpiarForm(){
    $('#nombreCompleto').val('');
    $('#dni').val('');
    $('#direccion').val('');
    $('#telefono').val('');
    $('#email').val('');
    $('#fechaLlegada').val('');
    $('#observacion').val('');
}

