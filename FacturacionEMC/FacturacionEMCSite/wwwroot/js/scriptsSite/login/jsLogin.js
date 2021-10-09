$(document).ready(function () {
    console.log("ready!");
    GetEmpresas();
   //toastr.warning("PRUEBA TOASTR");
    //toastr.success("Reinicio de politicas exitoso");
    //toastr.error("Error al reiniciar politicas");
});

function Login() {

    var empresa = $('#empresa').val();
    var userMail = $('#userMail').val();
    var password = $('#password').val();

    if (empresa === '' || userMail === '' || password === '') {
        toastr.warning("Todos los campos son nesesarios");
        return false;
    }

    $.ajax({
        type: "GET",
        url: urlLogin,
        data: { empresa: 1, userMail: 'asdas', password: 'dasdasd'},
        datatype: "json",
        success: function (data) {
            if (data.Descripcion === 'OK')
                window.Location.href = '';
            else
                toastr.warning("Usuario no autorizado / datos incorrectos");
        }
    });
    return false;
}

function GetEmpresas() {

    $.ajax({
        type: "POST",
        url: urlGetEmpresas,
        datatype: "json",
        success: function (data) {
            $('#empresa').empty();
            $('#empresa').append('<option value="" disabled selected>Seleccione empresa...</option>');
            $.each(data, function (index, item) {
                $('#empresa').append("<option value=\"" + item.Id + "\">" + item.Empresa + ' - ' + item.Servidor + ':' + item.Puerto + "</option>");
            });
        }
    });
    return false;
}



function GetAlmacenesPorIdConexion() {
    almacenesArray = [];
    var idConexion = $('#conexion').val();
    if (idConexion === '')
        return false;
    $.ajax({
        type: "GET",
        url: urlGetAlmacenesPorIdConexion,
        data: { id: idConexion },
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaAlmacenes tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> ${item.CveAlmacen} </td>
                      <td> ${item.Almacen} </td>
                      <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="RemoveAlmacen(${item.CveAlmacen})"><small><i class="mdi mdi-delete-forever"></i></small></a> </td>
                      </tr>`;
                    $('#tablaAlmacenes tbody').append(tr);
                });
                if (almacenesArray.length === 0) {
                    $.each(data, function (index, item) {
                        AgregarAlmacen(item.CveAlmacen.toString());
                    });
                }
            } else {
                $('#tablaAlmacenes tbody tr').remove();
            }
            InicializarDataTable();
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaAlmacenes tbody tr').remove();
        }
    });

    $("#tablaAlmacenes").addClass("display compact dt-center");
    return false;
}