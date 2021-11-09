$(document).ready(function () {
    console.log("ready!");
    GetEmpresas();
    $('#logout_').hide();
    $('#usuario_').hide();
    $('#dashboard_').hide();
    $('#fVenta_').hide();
    $('#fCompra_').hide();
    $('#rVenta_').hide();
    $('#rCompra_').hide();
    $('#stock_').hide();
    $('#asignacion_').hide();
    $('#inicioFact_').hide();
});

function Login() {

    var empresa = $('#empresa').val();
    var userMail = $('#userMail').val();
    var password = $('#password').val();
    var confirmar = document.getElementById('confirmar').checked;

    if (empresa === null || userMail === '' || password === '' || !confirmar) {
        toastr.warning("All fields are required");
        return false;
    }

    $.ajax({
        type: "GET",
        url: urlLogin,
        data: { idEmpresa: empresa, userMail: userMail, password: password},
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                if (data.estatusFacturacion)
                    window.location.href = urlRedirect;
                else
                    window.location.href = urlRedirectIF;
            }
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


