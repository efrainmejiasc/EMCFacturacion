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
    var confirmar = $('#confirmar').val();

    if (empresa === null || userMail === '' || password === '' && confirmar != 'on') {
        toastr.warning("All fields are required");
        return false;
    }

    $.ajax({
        type: "GET",
        url: urlLogin,
        data: { idEmpresa: empresa, userMail: userMail, password: password},
        datatype: "json",
        success: function (data) {
            if (data.estatus)
                window.location.href=urlRedirect
            else
                toastr.warning("Unauthorized user / incorrect data");
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
            $('#empresa').append('<option value="-1" disabled selected>Select company...</option>');
            $.each(data, function (index, item) {
                $('#empresa').append("<option value=\"" + item.id + "\">" + item.nombreEmpresa + "</option>");
            });
        }
    });
    return false;
}

function Reset() {
    $('#empresa').val('-1');
    $('#userMail').val('');
    $('#password').val('');
    $("#confirmar").prop("checked", false);
}

 function EmailValido(mail){
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
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