
$(document).ready(function () {
    console.log("ready!");
    GetMetodosPago();
    GetProveedores();
    GetUnidadesMedida();
    GetProductos();
    $('#pImpuesto').val('0.00');
    $('#pDescuento').val('0.00');
    $('#numeroLinea_').val(0)
});

function GetProveedores() {

    $.ajax({
        type: "GET",
        url: urlGetProveedores,
        datatype: "json",
        success: function (data) {
            $('#proveedor').empty();
            $('#proveedor').append('<option value="-1" disabled selected>Select supplier...</option>');
            $.each(data, function (index, item) {
                $('#proveedor').append("<option value=\"" + item.id + "\">" + item.nombreProveedor + "</option>");
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
    var idProveedor = $('#proveedor').val();
    var nFactura = $('#nFactura').val();
    var numero = parseInt($('#numeroLinea_').val());
    var articulo = $('#articulo').val();
    var unidad = $('#unidad').val();
    var descripcion = $('#descripcion').val();
    var cantidad = $('#cantidad').val();
    var precio = $('#precio').val();
    var subTotalLinea = $('#subTotalLinea').val();


    if (idProveedor === '-1' || articulo === '' || descripcion === '' || subTotalLinea <= 0 || unidad === '-1' || metodoPago === '-1' || nFactura === '') {
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
    var cantidad = $('#cantidad').val();
    var precio = $('#precio').val();

    var subtotal = (cantidad * precio);
    var subTotalFormat = parseFloat(subtotal).toFixed(2)
    $('#subTotalLinea').val(subTotalFormat);
}

//se ejecuta cada vez que se agrega o se elimina una linea
function SetTotalesTabla() {

    var cantidad = 0;
    var precio = 0;
    var subtotal = 0;

    //devuelve las filas del body de tu tabla segun el ejemplo que brindaste
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

    var idProveedor = $('#proveedor').val();
    var nombreProveedor = $("#proveedor option:selected").text();
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
    else if (idProveedor === '-1' || nFactura === '' || subtotal <= 0 || total <= 0 || pDescuento < 0 || pImpuesto < 0 || idMetodoPago ==='-1') {
        toastr.warning("All fields are required");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlGuardarFactura,
        data: { NumeroFactura: nFactura, IdProveedor: idProveedor, NombreProveedor: nombreProveedor, Subtotal: subtotal, PorcentajeDescuento: pDescuento, PorcentajeImpuesto: pImpuesto, Total: total, IdMetodoPago: idMetodoPago},
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


function MostrarModalProveedor() {
    $('#modalProveedor').show();
}

function OcultarModalProveedor() {
    $('#modalProveedor').hide();
    ResetModal();
}


function AgregarProveedor() {
    var nombre = $('#_nombre').val();
    var rfc = $('#_rfc').val();
    var email = $('#_email').val();
    var direccion = $('#_direccion').val();
    var telefono = $('#_telefono').val();

    if (nombre === '' || rfc === '' || email === '' || direccion === '' || telefono === '') {
        toastr.warning("All fields are required");
        return false;
    }
    else if (!EmailValido(email)){
        toastr.warning("Email no valid");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlAgregarProveedor,
        data: { nombreProveedor: nombre,  rfc: rfc ,email: email , direccion: direccion, telefono: telefono},
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                toastr.success("Supplier saved successfully");
                GetProveedores();
                setTimeout(OcultarModalProveedor, 4000);
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

function MostrarModalArticulo() {
    $('#modalArticulo').show();
}

function OcultarModalArticulo() {
    $('#modalArticulo').hide();
   // ResetModalArticulo();
}

function AgregarArticulo() {
    var nombre = $('#_nombreArt').val();
    var descripcion = $('#_descripcionArticulo').val();
    var precio = $('#_precioArticulo').val();
    var presentacion = $('#_presentacionArticulo').val();


    if (nombre === '' || descripcion  === '' || precio <= 0 || presentacion === '' ) {
        toastr.warning("All fields are required");
        return false;
    }
    $.ajax({
        type: "POST",
        url: urlAddProducto,
        data: { NombreProducto: nombre, Descripcion: descripcion, PrecioUnidad: precio, Presentacion: presentacion},
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                toastr.success("Article saved successfully");
                GetProductos();
                setTimeout(OcultarModalArticulo, 4000);
            }
            else
                toastr.error("Unexpected error");
        }
    });

    return false;
}

function SetArticulo() {
    var articulo = $("#lstArticulo option:selected").text();
    var id = $("#lstArticulo").val();
    $('#articulo').val(articulo + ' ' +id);
}

function GetProductos() {

    $.ajax({
        type: "GET",
        url: urlGetProductos,
        datatype: "json",
        success: function (data) {
            $('#lstArticulo').empty();
            $('#lstArticulo').append('<option value="-1" disabled selected>Select article...</option>');
            $.each(data, function (index, item) {
                $('#lstArticulo').append("<option value=\"" + item.id + "\">" + item.nombreProducto + " - " +  item.presentacion +"</option>");
            });
        }
    });

    return false;
}








