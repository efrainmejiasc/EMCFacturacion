var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    LimpiarForm();
    $('#usuario_').hide();
    GetRolesUsuario();
}


function GetRolesUsuario() {

    var userRol = cultureInfo == 'en-US' ? 'Select user rol...' : 'Seleccione rol de usuario...';
    var manager = cultureInfo == 'en-US' ? 'Manager' : 'Gerente';
    var client = cultureInfo == 'en-US' ? 'Client' : 'Cliente';
    var seller = cultureInfo == 'en-US' ? 'Seller' : 'Vendedor';

    $('#rol').empty();
    $('#rol').append('<option value="-1" disabled selected>' + userRol + '</option>');
    $('#rol').append("<option value=\"" + 1 + "\">" + manager + "</option>");
    $('#rol').append("<option value=\"" + 2 + "\">" + client + "</option>");
    $('#rol').append("<option value=\"" + 3 + "\">" + seller + "</option>");

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

    if (nombre === '' || apellido === '' || idRol === '' || username === '' || email === '' || password === '' || cpassword === '') {
        if(cultureInfo == 'en-US')
            toastr.warning("All fields are required");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Todos los campos son requeridos");

        return false;
    }
    else if (!EmailValido(email)) {
        if (cultureInfo == 'en-US')
            toastr.warning("The email not is valid.");
        else if (cultureInfo == 'es-ES')
            toastr.warning("El email no es valido.");

        return false;
    }
    else if (password != cpassword) {
        if (cultureInfo == 'en-US')
            toastr.warning("Passwords must be the same.");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Las contraseñas deben ser identicas.");

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
                if (cultureInfo == 'en-US')
                    toastr.success("Success creating the user.");
                else if (cultureInfo == 'es-ES')
                    toastr.success("Usuario creado exitosamente");
                
                setTimeout(LimpiarForm, 4000);
            }
            else
            {
                if (cultureInfo == 'en-US')
                    toastr.warning("User could not be created.");
                else if (cultureInfo == 'es-ES')
                    toastr.warning("El usuario no pudo ser creado");
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
