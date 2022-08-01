var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    cultureInfo = $('#cultureInfo').val();
    $('#fVenta_').hide();
    GetUsuarioLogger();
    $('#pImpuesto').val('0.00');
    $('#pDescuento').val('0.00');
    $('#numeroLinea_').val(0)
});

function GetUsuarioLogger() {

    $.ajax({
        type: "GET",
        url: urlUsuarioLogger,
        datatype: "json",
        success: function (data) {
            $('#empresaP').html(data.nombreEmpresa);
            console.log(data.nombreEmpresa);

            if (data.inicioFacturacion) {
                GetNumeroFactura();
                GetMetodosPago();
                GetClientes();
                GetUnidadesMedida();
                GetUnidadesMedida();
                GetProductos();
            } else {
                if (cultureInfo == 'en-US')
                    toastr.warning('You must set the billing start.');
                else if (cultureInfo == 'es-ES')
                    toastr.warning('Debes establecer el inicio de facturacion');
                setTimeout(function () { window.location.href = urlInicioFacturacion },3000);
            }
        }
    });
    return false;
}

function GetNumeroFactura() {

    $.ajax({
        type: "GET",
        url: urlNumeroFactura,
        datatype: "json",
        success: function (data) {
            $('#nFactura').val(data.numeroFactura);
        }
    });
    return false;
}

function GetClientes() {

    var client = cultureInfo == 'en-US' ? 'Select client...' : 'Seleccione cliente...';

    $.ajax({
        type: "GET",
        url: urlGetClientes,
        datatype: "json",
        success: function (data) {
            $('#cliente').empty();
            $('#cliente').append('<option value="-1" disabled selected>' + client +'</option>');
            $.each(data, function (index, item) {
                $('#cliente').append("<option value=\"" + item.id + "\">" + item.nombreCliente + "</option>");
            });
        }
    });
    return false;
}

function GetMetodosPago() {

    var payMethod = cultureInfo == 'en-US' ? 'Select pay method...' : 'Seleccione metodo de pago...';

    $.ajax({
        type: "GET",
        url: urlGetMetodosPago,
        datatype: "json",
        success: function (data) {
            $('#metodoPago').empty();
            $('#metodoPago').append('<option value="-1" disabled selected>' + payMethod + '</option>');
            $.each(data, function (index, item) {
                $('#metodoPago').append("<option value=\"" + item.id + "\">" + item.metodo + "</option>");
            });
        }
    });
    return false;
}

function GetUnidadesMedida() {

    var unit = cultureInfo == 'en-US' ? 'Select unit...' : 'Seleccione unidad de medida...';

    $.ajax({
        type: "GET",
        url: urlGetUnidadesMedida,
        datatype: "json",
        success: function (data) {
            $('#unidad').empty();
            $('#unidad').append('<option value="-1" disabled selected>' + unit + '</option>');
            $.each(data, function (index, item) {
                $('#unidad').append("<option value=\"" + item.id + "\">" + item.unidad + "</option>");
            });
        }
    });
    return false;
}


var lineasArray = [];

function AddLinea()
{
    var idCliente = $('#cliente').val();
    var numero = parseInt($('#numeroLinea_').val());
    var articulo = $('#articulo').val();
    var unidad = $('#unidad').val();
    var descripcion = $('#descripcion').val();
    var cantidad = $('#cantidad').val();
    var precio = $('#precio').val();
    var subTotalLinea = $('#subTotalLinea').val();

    if (idCliente === '-1' || articulo === '' || subTotalLinea <= 0 || unidad === '-1' || metodoPago === '-1') {
        if (cultureInfo == 'en-US')
            toastr.warning("All fields are required");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Todos los campos son requeridos");
        return false;
    }

    var Delete = cultureInfo == 'en-US' ? 'Delete' : 'Eliminar';

    let ln = `<tr id='r${numero}' >
                  <td style="display:none;"> ${numero} </td>
                  <td id='r${numero}1' > ${articulo} </td>
                  <td id='r${numero}2' > ${descripcion} </td>
                  <td id='r${numero}3' > ${cantidad} </td>
                  <td id='r${numero}4' > ${unidad} </td>
                  <td id='r${numero}5' > ${precio} </td>
                  <td id='r${numero}6' > ${subTotalLinea} </td>
                  <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="RemoveLinea(${numero})">${Delete}</a></td>
                  </tr>`;

    $('#tablaLineas  tr:last').after(ln);
    AddLineaArray('r' + numero);
    numero = numero + 1;
    $('#numeroLinea_').val(numero);

    $('#lstArticulo').val(-1)
    $('#articulo').val('')
    $('#descripcion').val('')
    $('#cantidad').val('');
    $('#precio').val('');
    $('#subTotalLinea').val('');
    $('#unidad').val('Unit');

    SetTotalesTabla();
}

function RemoveLinea(row) {
    RemoveLineaArray('r' + row);
    $("#r" + row).remove();
    var number = parseInt($('#numeroLinea_').val());
    number = number - 1 ;
    $('#numeroLinea_').val(number);

    SetTotalesTabla();
}

function AddLineaArray(id) {
    if (!lineasArray.includes(id)) {
        lineasArray.push(id);
    }
    else {
        return false;
    }
}

function RemoveLineaArray(id) {

    lineasArray.splice(lineasArray.indexOf(id), 1);
}

//metodo on blur precio
function SubtotalLinea() {
    var id = $('#lstArticulo').val();
    GetExistenciaArticuloBodega_(id);
    var cantidad = $('#cantidad').val();

    var precio = $('#precio').val();
    var subtotal = (cantidad * precio);
    var subTotalFormat = parseFloat(subtotal).toFixed(2)
    $('#subTotalLinea').val(subTotalFormat);
}


function GetExistenciaArticuloBodega_(id) {

    console.log(id);

    $.ajax({
        type: "GET",
        url: urlGetStockProductoBodega,
        data: { idArticulo: id },
        datatype: "json",
        success: function (data) {
            var cantidad = $('#cantidad').val();
            if (data.cantidad < cantidad) {
                if (cultureInfo == 'en-US')
                    toastr.warning("They only exist in stock: " + data.cantidad);
                else if (cultureInfo == 'es-ES')
                    toastr.warning("Solo existe en stock: " + data.cantidad);

            }
        }
    });
    console.log(' ');
} 


//se ejecuta cada vez que se agrega o se elimina una linea
function SetTotalesTabla() {

    var cantidad = 0;
    var precio = 0;
    var subtotal = 0;

    //devulve las filas del body de tu tabla segun el ejemplo que brindaste
    var nfilas = $("#tablaLineas").find("tr");

    for (var i = 1; i < nfilas.length; i++) {

        var celdas = $(nfilas[i]).find("td");

        cantidad = $(celdas[3]).text();
        precio = $(celdas[5]).text();
        subtotal = (subtotal + cantidad * precio)

        var subTotalFormat = parseFloat(subtotal).toFixed(2)
        $('#subtotal').val(subTotalFormat);
        $('#total').val(subTotalFormat);
    }
}

    
function GuardarFactura() {
    var idCliente = $('#cliente').val();
    var nombreCliente = $("#cliente option:selected").text();
    var nFactura = $('#nFactura').val();
    var subtotal = parseFloat($('#subtotal').val());
    var total = parseFloat($('#total').val());
    var pImpuesto = parseFloat($('#pImpuesto').val());
    var pDescuento = parseFloat($('#pDescuento').val());
    var idMetodoPago = $('#metodoPago').val();

    var rows = $('#tablaLineas tr').length -1;

    if (rows === 0) {
        if (cultureInfo == 'en-US')
            toastr.warning("You must add invoice detail");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Debes agregar detalle de la factura");

        return false;
    }
    else if (idCliente === '-1' || nFactura === '' || subtotal <= 0 || total <= 0 || pDescuento < 0 || pImpuesto < 0 || idMetodoPago === '-1') {
        if (cultureInfo == 'en-US')
            toastr.warning("All fields are required");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Todos los campos son requeridos");

        return false;
    }

    var newSub = subtotal.toString();
    newSub = newSub.replace('.', ',');

    $.ajax({
        type: "POST",
        url: urlGuardarFactura,
        data: { NumeroFactura: nFactura, Subtotal: newSub, PorcentajeDescuento: pDescuento, PorcentajeImpuesto: pImpuesto, Total: newSub, IdCliente: idCliente, NombreCliente: nombreCliente, IdMetodoPago: idMetodoPago },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                GuardarFacturaDetalle();
            }
            else {
                if (cultureInfo == 'en-US')
                    toastr.error("Unexpected error");
                else if (cultureInfo == 'es-ES')
                    toastr.error("Error inesperado");
            }
        }
    });

     return false;
}



function GuardarFacturaDetalle()
{
    var FacturaDetalleDTO = new Array();
    var nfilas = $("#tablaLineas").find("tr");
    var nFactura = $('#nFactura').val();
    var pImpuesto = parseFloat($('#pImpuesto').val());
    var pDescuento = parseFloat($('#pDescuento').val());

    for (var i = 1; i < nfilas.length; i++) {
        var celdas = $(nfilas[i]).find("td");
        var x = {};
        x.Linea = parseInt(i);
        x.NumeroFactura = nFactura;
        x.NombreArticulo = $(celdas[1]).text();
        x.Descripcion = $(celdas[2]).text();
        x.Cantidad = parseInt($(celdas[3]).text());
        x.Unidad = $(celdas[4]).text();
        x.PrecioUnitario = parseFloat($(celdas[5]).text());
        x.Subtotal = parseFloat($(celdas[6]).text());
        x.IdArticulo = 0;
        x.PorcentajeImpuesto = pImpuesto;
        x.Impuesto = 0;
        x.PorcentajeDescuento = pDescuento;
        x.Descuento = 0;
        x.Total = parseFloat($(celdas[6]).text());
        x.Fecha = FechaActual();
        x.FechaModificacion = FechaActual();
        x.IdUsuario = 0;
        x.Activo = true;

        FacturaDetalleDTO.push(x);
    }

    $.ajax({
        type: "POST",
        url: urlGuardarFacturaDetalle,
        data: { facturaDetalle: JSON.stringify(FacturaDetalleDTO) },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                if (cultureInfo == 'en-US')
                    toastr.success("Invoice saved successfully");
                else if (cultureInfo == 'es-ES')
                    toastr.success("Factura guardada correctamente");
                setTimeout(RecargarPagina, 4000);
            }
            else {
                if (cultureInfo == 'en-US')
                    toastr.error("Unexpected error");
                else if (cultureInfo == 'es-ES')
                    toastr.error("Error inesperado");
            }
        }
    });

    return false;
}

function RecargarPagina() {
    location.reload(true);
}

function FechaActual() {
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    return date;
}


function MostrarModalCliente() {
    $('#modalCliente').show();
}

function OcultarModalCliente() {
    $('#modalCliente').hide();
    ResetModal();
}


function AgregarCliente() {
    var nombre = $('#_nombre').val();
    var rfc = $('#_rfc').val();
    var email = $('#_email').val();
    var direccion = $('#_direccion').val();
    var telefono = $('#_telefono').val();

    if (nombre === '' || rfc === '' || email === '' || direccion === '' || telefono === '') {
        if (cultureInfo == 'en-US')
            toastr.warning("All fields are required");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Todos los campos son requeridos");
        return false;
    }
    else if (!EmailValido(email)) {
        if (cultureInfo == 'en-US')
            toastr.warning("Email no valid");
        else if (cultureInfo == 'es-ES')
            toastr.warning("Email no valido");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlAgregarCliente,
        data: { nombreCliente: nombre, rfc: rfc, email: email, direccion: direccion, telefono: telefono },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                if (cultureInfo == 'en-US')
                    toastr.success("Client saved successfully.");
                else if (cultureInfo == 'es-ES')
                    toastr.success("Cliente guardado correctamente.");
                GetClientes();
                setTimeout(OcultarModalCliente, 4000);
            }
            else
            {
                if (cultureInfo == 'en-US')
                    toastr.error("Unexpected error");
                else if (cultureInfo == 'es-ES')
                    toastr.error("Error inesperado");
            }
        }
    });

    return false;
}

function EmailValido(mail) {
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
}

function ResetModal() {
    $('#_nombre').val('');
    $('#_rfc').val('');
    $('#_email').val('');
    $('#_direccion').val('');
    $('#_telefono').val('');
}

function SetArticulo() {
    var articulo = $("#lstArticulo option:selected").text();
    var id = $("#lstArticulo").val();
    $('#articulo').val(articulo + ' ' + id);
    GetPrecio(id);
}

/*function GetStockProductoBodega(idArticulo) {

    $.ajax({
        type: "GET",
        url: urlGetStockProductoBodega,
        data: { idArticulo: idArticulo },
        datatype: "json",
        success: function (data) {

            return data.cantidad;
        }
    });

    return 0;
}*/

var productosArray = [] ;
function GetProductos() {

    var article = cultureInfo == 'en-US' ? 'Select article...' : 'Seleccione articulo...';

    $.ajax({
        type: "GET",
        url: urlGetProductos,
        datatype: "json",
        success: function (data) {
            productosArray = data;
            $('#lstArticulo').empty();
            $('#lstArticulo').append('<option value="-1" disabled selected>' + article +'</option>');
            $.each(data, function (index, item) {
                $('#lstArticulo').append("<option value=\"" + item.id + "\">" + item.nombreProducto + " - " + item.presentacion + "</option>");
            });
        }
    });

    return false;
}

function GetPrecio(id) {
    var producto = productosArray.find(element => element.id == id);
    $('#precio').val(producto.precioUnidad);
    document.getElementById("precio").focus();
}


function MostrarModalPrinter() {
    SetTickket();
    $('#printer_').show();
}

function OcultarModalPrinter() {
    var nfilas = $("#tablaTicket").find("tr");

    for (var i = 1; i < nfilas.length; i++) {
        $('#a' + i + '1').remove();
        $('#a' + i + '2').remove();
        $('#a' + i + '3').remove();
        $('#a' + i + '4').remove();
    }
 
    $('#printer_').hide();
}


function SetTickket() {
    $('#tablaTicket > tbody > tr').remove();

    var nfilas = $("#tablaLineas").find("tr");
    var nFactura = $('#nFactura').val();
    var pImpuesto = parseFloat($('#pImpuesto').val());
    var pDescuento = parseFloat($('#pDescuento').val());

    for (var i = 1; i < nfilas.length; i++) {
        var celdas = $(nfilas[i]).find("td");
        var x = {};
        x.Linea = parseInt(i);
        x.NumeroFactura = nFactura;
        x.NombreArticulo = $(celdas[1]).text();
        x.Descripcion = $(celdas[2]).text();
        x.Cantidad = parseInt($(celdas[3]).text());
        x.Unidad = $(celdas[4]).text();
        x.PrecioUnitario = parseFloat($(celdas[5]).text());
        x.Subtotal = parseFloat($(celdas[6]).text());
        x.IdArticulo = 0;
        x.PorcentajeImpuesto = pImpuesto;
        x.Impuesto = 0;
        x.PorcentajeDescuento = pDescuento;
        x.Descuento = 0;
        x.Total = parseFloat($(celdas[6]).text());


        let ln = `<tr>
                  <td id='a${i}1'> ${x.NombreArticulo} </td>
                  <td id='a${i}2'> ${x.PrecioUnitario} </td>
                  <td id='a${i}3'> ${x.Cantidad} </td>
                  <td id='a${i}4'> ${x.Subtotal} </td>
                  </tr>`;

        $('#tablaTicket  tr:last').after(ln);
    }

    return false;
}


function ImprimirTicket() {
    var divContents = document.getElementById("impresionante").innerHTML;
    var a = window.open('', '', 'height=500, width=500');
   // a.document.write('<html>');
   // a.document.write('<body > <h1>Div contents are <br>');
    a.document.write(divContents);
   // a.document.write('</body></html>');
    a.document.close();
    a.print();
}

function Reset() {
    location.reload();
}





