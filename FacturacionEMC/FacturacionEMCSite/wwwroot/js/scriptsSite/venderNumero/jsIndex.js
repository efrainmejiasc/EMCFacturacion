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
}

function Guardar() {

    if (!ValidarTicket())
        return false;
        
}

function Imprimir() {
    if (ValidarTicket()) {
        var divContents = document.getElementById("impresionante").innerHTML;
        var textareaValue = document.getElementById("lst").value;
        var inputValue = document.getElementById("toLoteria").value;

        var printContents = divContents.replace('<textarea id="lst" class="form-control" rows="8" disabled style="width:200px"></textarea>', textareaValue);
        printContents = printContents.replace('<input type="text" id="toLoteria" class="form-control" disabled style="width:200px">', inputValue);

        var a = window.open('', '', 'height=500, width=500');
        a.document.write(printContents);
        a.document.close();
        a.print();
    }

    return false;
}



function ValidarTicket() {
    var loterias = $('#toLoteria').val();
    var warning = cultureInfo == 'en-US' ? 'Add a lottery.' : 'Agrega una loteria.';
    if (loterias === '') {
        toastr.warning(warning);
        return false;
    }
    warning = cultureInfo == 'en-US' ? 'Error in number. ' : 'Error en numero. ';
    var textarea = $('#lst').val();
    var lines = textarea.split('\n');
    for (var i = 0; i < lines.length; i++) {
        var linea = lines[i];
        var partes = linea.split('x');
        var numero = partes[0];
        var valor = partes[1];
        if (numero === '' || valor === '') {
            toastr.warning(warning + i);
            return false;
        }
    }

    return true;
}

