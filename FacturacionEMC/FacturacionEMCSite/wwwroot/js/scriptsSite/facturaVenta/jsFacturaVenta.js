
$(document).ready(function () {
    console.log("ready!");
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
            if (data.inicioFacturacion) {
                GetNumeroFactura();
                GetMetodosPago();
                GetClientes();
                GetUnidadesMedida();
                GetUnidadesMedida();
                GetProductos();
            } else {
                toastr.warning('You must set the billing start.');
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
    $.ajax({
        type: "GET",
        url: urlGetClientes,
        datatype: "json",
        success: function (data) {
            $('#cliente').empty();
            $('#cliente').append('<option value="-1" disabled selected>Select client...</option>');
            $.each(data, function (index, item) {
                $('#cliente').append("<option value=\"" + item.id + "\">" + item.nombreCliente + "</option>");
            });
        }
    });
    return false;
}

function GetMetodosPago() {
    $.ajax({
        type: "GET",
        url: urlGetMetodosPago,
        datatype: "json",
        success: function (data) {
            $('#metodoPago').empty();
            $('#metodoPago').append('<option value="-1" disabled selected>Select pay method...</option>');
            $.each(data, function (index, item) {
                $('#metodoPago').append("<option value=\"" + item.id + "\">" + item.metodo + "</option>");
            });
        }
    });
    return false;
}

function GetUnidadesMedida() {
    $.ajax({
        type: "GET",
        url: urlGetUnidadesMedida,
        datatype: "json",
        success: function (data) {
            $('#unidad').empty();
            $('#unidad').append('<option value="-1" disabled selected>Select unit...</option>');
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

    if (idCliente === '-1' || articulo === '' || descripcion === '' || subTotalLinea <= 0 || unidad === '-1' || metodoPago === '-1') {
        toastr.warning("All fields are required");
        return false;
    }


    let ln = `<tr id='r${numero}' >
                  <td style="display:none;"> ${numero} </td>
                  <td id='r${numero}1' > ${articulo} </td>
                  <td id='r${numero}2' > ${descripcion} </td>
                  <td id='r${numero}3' > ${cantidad} </td>
                  <td id='r${numero}4' > ${unidad} </td>
                  <td id='r${numero}5' > ${precio} </td>
                  <td id='r${numero}6' > ${subTotalLinea} </td>
                  <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="RemoveLinea(${numero})">Delete</a></td>
                  </tr>`;

    $('#tablaLineas  tr:last').after(ln);
    AddLineaArray('r' + numero);
    numero = numero + 1;
    $('#numeroLinea_').val(numero);

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
    var existencia = GetStockProductoBodega(id);
    console.log('Existencia : ' + existencia);

    var cantidad = $('#cantidad').val();
    var precio = $('#precio').val();

    var subtotal = (cantidad * precio);
    var subTotalFormat = parseFloat(subtotal).toFixed(2)
    $('#subTotalLinea').val(subTotalFormat);
}


function GetStockProductoBodega(idArticulo) {

    console.log(idArticulo);
    $.ajax({
        type: "GET",
        url: urlGetStockProductoBodega,
        data: { idArticulo: idArticulo },
        datatype: "json",
        success: function (data) {
            console.log(data);
            return data.cantidad;
        }
    });

    console.log('hola mundo');
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
        toastr.warning("You must add invoice detail");
        return false;
    }
    else if (idCliente === '-1' || nFactura === '' || subtotal <= 0 || total <= 0 || pDescuento < 0 || pImpuesto < 0 || idMetodoPago === '-1') {
        toastr.warning("All fields are required");
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
            else
                toastr.error("Unexpected error");
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
                toastr.success("Invoice saved successfully");
                setTimeout(RecargarPagina, 4000);
            }
            else
                toastr.error("Unexpected error");
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
        toastr.warning("All fields are required");
        return false;
    }
    else if (!EmailValido(email)) {
        toastr.warning("Email no valid");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlAgregarCliente,
        data: { nombreCliente: nombre, rfc: rfc, email: email, direccion: direccion, telefono: telefono },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                toastr.success("Client saved successfully");
                GetClientes();
                setTimeout(OcultarModalCliente, 4000);
            }
            else
                toastr.error("Unexpected error");
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

function GetStockProductoBodega(idArticulo) {

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
}

var productosArray = [] ;
function GetProductos() {

    $.ajax({
        type: "GET",
        url: urlGetProductos,
        datatype: "json",
        success: function (data) {
            productosArray = data;
            $('#lstArticulo').empty();
            $('#lstArticulo').append('<option value="-1" disabled selected>Select article...</option>');
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




