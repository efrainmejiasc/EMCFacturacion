$(document).ready(function () {
    console.log("ready!");
    LimpiarForm();
    $('#usuario_').hide();
    GetRolesUsuario();
    var cultureInfo = $('#cultureInfo').val();
    console.log(cultureInfo)
});

function GetRolesUsuario() {

    $('#rol').empty();
    $('#rol').append('<option value="-1" disabled selected>Select user rol...</option>');
    $('#rol').append("<option value=\"" + 1 + "\">" + 'Manager' + "</option>");
    $('#rol').append("<option value=\"" + 2 + "\">" + 'Client' + "</option>");
    $('#rol').append("<option value=\"" + 3 + "\">" + 'Seller' + "</option>");

    return false;

}


function CrearUsuario()
{
    var nombre = $('#nombre').val();
    var apellido = $('#apellido').val();
    var idRol = $('#rol').val();
    var username = $('#username').val();
    var email = $('#email').val();
    var password = $('#password').val();
    var cpassword = $('#cpassword').val();

    console.log(password + ' ' + cpassword);

    if ( nombre === '' || apellido === '' || idRol === '' || username === '' || email === '' || password === '' || cpassword === '') {
        toastr.warning("All fields are required");
        return false;
    }
    else if (!EmailValido(email)) {
        toastr.warning("The email not is valid.");
        return false;
    }
    else if (password != cpassword ) {
        toastr.warning("Passwords must be the same.");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlAddUsuario,
        data: {Nombre: nombre, Apellido: apellido, IdRol: idRol, UserName: username, Email: email, Password: password },
        datatype: "json",
        success: function (data) {
            if (data.estatus)
            {
                toastr.success("Success creating the user.");
                setTimeout(LimpiarForm, 4000);
            }
            else
            {
                toastr.warning("User could not be created.");
            }
        }
    });

    return false;
}

function EmailValido(mail) {
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
}

function LimpiarForm() {
    $('#rol').val('');
    $('#username').val('');
    $('#email').val('');
    $('#password').val('');
    $('#cpassword').val('');
    $('#nombre').val('');
    $('#apellido').val('');
}

function GotoUsers() {
    window.location.href = urlAllUsers ;
}
