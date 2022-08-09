var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    GetEmpresas();

}

function Login() {

    var empresa = $('#empresa').val();
    var nombreEmpresa = $("#empresa option:selected").text();
    var userMail = $('#userMail').val();
    var password = $('#password').val();
    var confirmar = document.getElementById('confirmar').checked;

    if (empresa === null || userMail === '' || password === '' || !confirmar) {
        if (cultureInfo == 'en-US')
            toastr.warning("All fields are required.");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Todos los campos son requeridos.");

        return false;
    }

    $.ajax({
        type: "GET",
        url: urlLogin,
        data: { idEmpresa: empresa, userMail: userMail, password: password, nombreEmpresa: nombreEmpresa },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                if (data.estatusFacturacion)
                    window.location.href = urlRedirect;
                else
                    window.location.href = urlRedirectIF;
            }
            else {
                if (cultureInfo == 'en-US')
                    toastr.warning("Unauthorized user / incorrect data");
                else if (cultureInfo == 'es-ES')
                    toastr.warning("Usuario no autorizado / datos incorectos");

            }
        }
    });
    return false;
}

function GetEmpresas() {

    var empresa = cultureInfo == 'en-US' ? 'Select company...' : 'Seleccione empresa...';

    $.ajax({
        type: "POST",
        url: urlGetEmpresas,
        datatype: "json",
        success: function (data) {
            $('#empresa').empty();
            $('#empresa').append('<option value="-1" disabled selected>' + empresa + '</option>');
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


