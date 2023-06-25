var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    $('#fechaSorteo').val(FechaSorteo());
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
        var ticket = $('#ticket').text();
        var toLoteria = $('#toLoteria').val();
        var lst = $('#lst').val();

        var printContents = ticket + "<br>" + toLoteria + "<br>";
        var lines = lst.split('\n');
        for (var i = 0; i < lines.length; i++) {
            var linea = lines[i];
            if (linea !== '') {
                printContents = printContents + linea +  "<br>";
            }
        }

        printContents = printContents + FechaActual();
        var a = window.open('', '', 'height=500, width=500');
        a.document.write(printContents);
        a.document.close();
        a.print();
    }

    return false;
}



function ValidarTicket() {
    var VentaNumeroDTO = new Array();
    var ticket = $('#ticket').text();
    var fechaActual = FechaActual();
    var fechaSorteo = $('#fechaSorteo').val();
    var loterias = $('#toLoteria').val();
    var warning = cultureInfo == 'en-US' ? 'Add a lottery.' : 'Agrega una loteria.';
    if (loterias === '') {
        toastr.warning(warning);
        return false;
    }
    warning = cultureInfo == 'en-US' ? 'Ticket is empty.' : 'El ticket no puede ser vacio.'; 
    if (ticket === '') {
        toastr.warning(warning);
        return false;
    }
    warning = cultureInfo == 'en-US' ? 'Date Lottery is empty.' : 'Fecha sorteo no puede ser vacia.';
    if (fechaSorteo === '') {
        toastr.warning(warning);
        return false;
    }
    warning = cultureInfo == 'en-US' ? 'Error in number. ' : 'Error en numero. ';
    var loteriasLst = loterias.split('-');
    var textarea = $('#lst').val();
    var lines = textarea.split('\n');
    for (var i = 0; i < lines.length; i++) {
        var linea = lines[i];
        if (linea !== '')
        {
            for (var j = 0; j < loteriasLst.length - 1; j++) {
                var partes = linea.split('x');
                var numero = partes[0];
                var valor = partes[1];
                if (numero === '' || valor === '') {
                    toastr.warning(warning + i);
                    return false;
                }
                var x = {};
                x.Vendedor = '';
                x.Numero = numero;
                x.Telefono = '';
                x.Email = '';
                x.Loteria = loteriasLst[j];
                x.Activo = true;
                x.FechaVenta = fechaActual;
                x.FechaSorteo = fechaSorteo;
                x.IdEmpresa = '';
                x.Monto = valor;
                x.ticket = ticket;
                VentaNumeroDTO.push(x);
            }
           
        }
    }
    console.log(VentaNumeroDTO);
    return true;
}


function FechaActual() {
    var today = new Date();
    var year = today.getFullYear();
    var moth = (today.getMonth() + 1) <= 9 ? "0" + (today.getMonth() + 1) : (today.getMonth() + 1);
    var day = today.getDate() <= 9 ? "0" + today.getDate() : today.getDate();

    var date = '';
    if (cultureInfo == 'en-US')
        date = year + '-' + moth + '-' + day;
    else if (cultureInfo == 'es-ES')
        date = day + '-' + moth + '-' + year;
    
    return date;
}

function FechaSorteo() {

    var today = new Date();
    var year = today.getFullYear();
    var moth = (today.getMonth() + 1) <= 9 ? "0" + (today.getMonth() + 1) : (today.getMonth() + 1);
    var day = today.getDate() <= 9 ? "0" + today.getDate() : today.getDate();
    var date = year + '-' + moth + '-' + day;

    return date;
}
