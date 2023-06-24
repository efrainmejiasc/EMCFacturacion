var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    GetLoterias();
}

function GetLoterias() {

    var client = cultureInfo == 'en-US' ? 'Select lot...' : 'Seleccione loteria...';

    $.ajax({
        type: "GET",
        url: urlGetLoterias,
        datatype: "json",
        success: function (data) {
            $('#loteria').empty();
            $('#loteria').append('<option value="-1" disabled selected>' + client + '</option>');
            $.each(data, function (index, item) {
                $('#loteria').append("<option value=\"" + item.id + "\">" + item.nombre + "</option>");
            });
        }
    });
    return false;
}

function AddLoteria() {
    var loteria = $('#loteria').val();
    var toLoteria = $('#toLoteria').val();

   if (!toLoteria.includes(loteria)) {
        var lot = toLoteria.concat(loteria , '-');
        $('#toLoteria').val('');
        $('#toLoteria').val(lot);
    }
}


function QuitLoteria() {
    var loteria = $('#loteria').val();
    var toLoteria = $('#toLoteria').val();
    var strLot = '';

    if (toLoteria.includes(loteria)) {
       strLot = strLot.concat(loteria, '-');
       var lot = toLoteria.replace(strLot, '');
       $('#toLoteria').val(lot);
    }
}

function SetTicket(n, f) {

    var lst = $('#lst').val();

    if (f !== '' && f === 'x') {
        lst = lst + f;
        $('#lst').val(lst);
        return false;
    }

    if (f !== '' && f === 'c') {
        lst = lst.substring(0,lst.length - 1);
        $('#lst').val(lst);
        return false;
    }

    if (n !== '') {
        lst = lst + n;
        $('#lst').val(lst);
        return false;
    }
}

function Nuevo() {

    let textarea = $('#lst').val();
    textarea = textarea.concat("\n");
    $('#lst').val(textarea);
    let lineas = textarea.value.split("\n");

    for (let i = 0; i < lineas.length; i++) {
        let linea = lineas[i];
        console.log(linea);
    }

}