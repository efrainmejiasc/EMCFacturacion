
$(document).ready(function () {
    console.log("ready!");
    $('#subtotal').val('0.00');
    $('#pDescuento').val('0.00');
    $('#pImpuesto').val('0.00');
    $('#total').val('0.00');
    $('#cantidad').val('0');
    $('#precio').val('0.00');
    $('#subTotalLinea').val('0.00')
    $('#numeroLinea_').val(0)
});

var lineasArray = [];

function AddLinea()
{
    var numero = parseInt($('#numeroLinea_').val());
    var articulo = $('#articulo').val();
    var unidad = $('#unidad').val();
    var descripcion = $('#descripcion').val();
    var cantidad = $('#cantidad').val();
    var precio = $('#precio').val();
    var subTotalLinea = $('#subTotalLinea').val();

    if (articulo === '' || descripcion === '' || subTotalLinea <= 0) {
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
                  <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="RemoveLinea(${numero})"><small><i class="mdi mdi-delete-forever"></i></small></a></td>
                  </tr>`;

    $('#tablaLineas  tr:last').after(ln);
    AddLineaArray('r' + numero);
    numero = numero + 1;
    $('#numeroLinea_').val(numero);

    $('#articulo').val('')
    $('#descripcion').val('')
    $('#cantidad').val('0');
    $('#precio').val('0.00');
    $('#subTotalLinea').val('0.00')

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

    var subtotal = cantidad * precio;
    $('#subTotalLinea').val(subtotal);
}

//se ejecuta cada vez que se agrega o se elimina una linea
function SetTotalesTabla() {

    var cantidad = 0;
    var precio = 0;
    var subtotal = 0;

    //devulve las filas del body de tu tabla segun el ejemplo que brindaste
    var nfilas = $("#tablaLineas").find("tr");
    console.log(nfilas);

    for (var i = 1; i < nfilas.length; i++) {

        var celdas = $(nfilas[i]).find("td");

        cantidad = $(celdas[3]).text();
        precio = $(celdas[5]).text();
        subtotal = subtotal + cantidad * precio

        $('#subtotal').val(subtotal);
        $('#total').val(subtotal);
    }
}

    
function GuardarFactura() {

    var idProveedor = $('#proveedor').val();
    var nFactura = $('#nFactura').val();
    var subtotal = $('#subtotal').val();
    var total = $('#total').val();
    var pImpuesto = $('#pImpuesto').val();
    var pDescuento = $('#pDescuento').val();
    var rows = $('#tablaLineas tr').length - 1;

    if (rows === 0) {
        toastr.warning("The total must be greater than zero");
        return false;
    }
    else if (idProveedor === '' || nFactura === '' || subtotal === 0 || total === 0 || pDescuento == '' || pImpuesto === '') {
        toastr.warning("The total must be greater than zero");
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlGuardarFactura,
        data: {IdProveedor: idProveedor, NumeroFactura: nFactura, Subtotal: subtotal, PorcentajeDescuento: pDescuento, PorcentajeImpuesto: pImpuesto, Total: total },
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

    for (var i = 1; i < nfilas.length; i++) {
        var celdas = $(nfilas[i]).find("td");
        var x = {};
        x.Linea = parseInt(i);
        x.NombreArticulo = $(celdas[1]).text();
        x.Descripcion = $(celdas[2]).text();
        x.Cantidad = parseInt($(celdas[3]).text());
        x.Unidad = $(celdas[4]).text();
        x.Precio = parseFloat($(celdas[5]).text());
        x.Subtotal = parseFloat($(celdas[6]).text());

        FacturaDetalleDTO.push(x);
    }
    console.log(FacturaDetalleDTO);

    $.ajax({
        type: "POST",
        url: urlGuardarFacturaDetalle,
        data: JSON.stringify(FacturaDetalleDTO),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            if (data.estatus) 
                toastr.success("Invoice saved successfully")
            else
                toastr.error("Unexpected error");
        }
    });

    return false;
}



/*let items = []
//let itemObj = {}
$('td').each(function () {
    if ($(this).attr('id')) {
        items.push($(this).text());

        //Alternativamente con creando un Objeto
        //itemObj[$(this).attr('id')] = $(this).text();
    }
});
console.log(items);
//console.log(itemObj);


const porFila = [];
while (items.length)
    porFila.push(items.splice(0, 6));

console.log(porFila);
   var linea = 0;
    var articulo = '';
    var descripcion = '';
    var cantidad = 0;
    var unidad = '';
    var precio = 0;
    var subtotal = 0;*/





