var cultureInfo = '';
var teclasN = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
var teclasL = ['x', 'X', 'c', 'C'];
$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);

    //$('#lst').on('blur', function () {
    //    var inputValue = $(this).val();
    //    var sanitizedValue = sanitizeInput(inputValue);
    //    var valor =
    //    $(this).val(sanitizedValue);
    //});
   
    $("#email, #lst","#telefono","#nombre").on("keydown", function (event) {
        var elementId = event.target.id;
        var keyPressed = event.key;
        if('email' === elementId)
            console.log(elementId);

        if (teclasN.includes(keyPressed))
            SetTicket(keyPressed, null);
        else (teclasL.includes(keyPressed))
            SetTicket(null, keyPressed.toLowerCase());
    });

});

function sanitizeInput(input) {
    // Remueve todos los caracteres que no sean números, 'X' o 'C'
    return input.replace(/[^0-9XC]/g, '');
}

function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    $('#fechaSorteo').val(FechaSorteo());
    GetNumeroTicket();
    GetLoterias();
    setTimeout(AddLoteria, 2000);
}

function GetNumeroTicket() {

    $.ajax({
        type: "GET",
        url: urlGetNumeroTicket,
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#ticket').text(data.numeroTicket);
            } else {
                toastr.error('Error');
            }
        }
    });
    return false;
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
            $("#loteria").val('Tachira')
        }
    });
    return false;
}

function AddLoteria() {
    var loteria = $('#loteria').val();
    var toLoteria = $('#toLoteria').val();

    if (loteria == null || loteria == '')
        return false;

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
    if (textarea !== '') {
        textarea = textarea.concat("\n");
        $('#lst').val(textarea);
    }
}

function Guardar() {

    if (!ValidarTicket())
        return false;

    setTimeout(GetNumeroTicket,10000); 
}

async function Imprimir() {
    var result = await ValidarTicket();
    if (result) {
        var ticket = $('#ticket').text();
        var toLoteria = $('#toLoteria').val();
        var lst = $('#lst').val();

        var fechaSorteo = $('#fechaSorteo').val();
        var printContents = '<style>@media print { @page { size: 750px 1000px; margin: 0; } body { font-size: 12px; font-family: Arial, sans-serif; margin: 20px; } }</style>';
        printContents += ticket + "<br>" + toLoteria + "<br>";
        var lines = lst.split('\n');
        for (var i = 0; i < lines.length; i++) {
            var linea = lines[i];
            if (linea !== '') {
                printContents += linea + "<br>";
            }
        }

        printContents += 'FA:' + FechaActual() + '<br>' + 'FS:' + fechaSorteo;
        var a = window.open('', '', 'height=500, width=500');
        a.document.write(printContents);
        a.document.close();
        a.print();
    }

    return false;
}




async function ValidarTicket() {
    var VentaNumeroDTO = [];
    var guid = generarGUID();
    var ticket = $('#ticket').text();
    var fechaActual = FechaActual();
    fechaActual = FormatearFechaVenta(fechaActual);
    var fechaSorteo = $('#fechaSorteo').val();
    var loterias = $('#toLoteria').val();
    var email = $('#email').val();
    var nombre = $('#nombre').val();
    var telefono = $('#telefono').val();
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
        if (linea !== '') {
            for (var j = 0; j < loteriasLst.length - 1; j++) {
                var partes = linea.split('x');
                var numero = partes[0];
                var valor = partes[1];
                if (numero === '' || valor === '') {
                    toastr.warning(warning + i);
                    return false;
                }
                var ventaNumero = {
                    Id: 0,
                    Identificador: '',
                    Vendedor: '',
                    Numero: parseInt(numero),
                    Telefono: telefono,
                    nombre: nombre,
                    Email: email,
                    Loteria: loteriasLst[j],
                    Activo: true,
                    FechaVenta: fechaActual,
                    FechaSorteo: fechaSorteo,
                    IdEmpresa: 0,
                    Monto: parseFloat(valor),
                    Premiado: 0,
                    TotalVendido: 0,
                    Identificador: guid,
                    Ticket: ticket
                };
                VentaNumeroDTO.push(ventaNumero);
            }
        }
    }
    console.log(VentaNumeroDTO);

    return new Promise(function (resolve, reject) {
        $.ajax({
            type: 'POST',
            url: urlGuardarTicket,
            data: { VentaNumeroDTO: JSON.stringify(VentaNumeroDTO) },
            datatype: 'json',
            success: function (data) {
                console.log(data);
                if (data.estatus) {
                    if (cultureInfo == 'en-US')
                        toastr.success("Ticket saved successfully");
                    else if (cultureInfo == 'es-ES')
                        toastr.success("Ticket guardado correctamente");

                    resolve(true);
                }
                else {
                    if (cultureInfo == 'en-US')
                        toastr.error("Unexpected error");
                    else if (cultureInfo == 'es-ES')
                        toastr.error("Error inesperado");

                    resolve(false);
                }
            },
            error: function () {
                toastr.error('ERROR...')
                resolve(false);
            }
        });
    });

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

function FormatearFechaVenta(f) {

    var partes = f.split('-');

    return partes[2] + '-' + partes[1] + '-' + partes[0]
}

function generarGUID() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }

    return (
        s4() +
        s4() +
        '-' +
        s4() +
        '-' +
        s4() +
        '-' +
        s4() +
        '-' +
        s4() +
        s4() +
        s4()
    );
}


    function ClearForm() {
        DocumentoListo();
        $('#lst').val('');
        $('#email').val('');
        $('#nombre').val('');
        $('#telefono').val('');
    }


