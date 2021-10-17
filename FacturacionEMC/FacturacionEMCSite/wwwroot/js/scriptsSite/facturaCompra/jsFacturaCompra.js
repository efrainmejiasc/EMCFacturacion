﻿
$(document).ready(function () {
    console.log("ready!");
    GetProveedores();
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

    if (idProveedor === '-1' || nFactura === '') {
        toastr.warning("Select supplier and add invoice number");
        return false;
    }
    else if (articulo === '' || descripcion === '' || subTotalLinea <= 0) {
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

    var idProveedor = $('#proveedor').val();
    var nombreProveedor = $("#proveedor option:selected").text();
    console.log(idProveedor);
    var nFactura = $('#nFactura').val();
    var subtotal = parseFloat($('#subtotal').val());
    var total = parseFloat($('#total').val());
    var pImpuesto = parseFloat($('#pImpuesto').val());
    var pDescuento = parseFloat($('#pDescuento').val());

    var rows = $('#tablaLineas tr').length -1;

    if (rows === 0) {
        toastr.warning("You must add invoice detail");
        return false;
    }
    else if (idProveedor === '-1' || nFactura === '' || subtotal <= 0 || total <= 0 || pDescuento < 0 || pImpuesto < 0) {
        toastr.warning("All fields are required");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlGuardarFactura,
        data: { NumeroFactura: nFactura, IdProveedor: idProveedor, NombreProveedor: nombreProveedor, Subtotal: subtotal, PorcentajeDescuento: pDescuento, PorcentajeImpuesto: pImpuesto, Total: total },
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
}









