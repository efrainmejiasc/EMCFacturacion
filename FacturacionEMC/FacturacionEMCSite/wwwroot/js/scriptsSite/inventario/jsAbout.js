$(document).ready(function () {
    console.log('ready!');
    $('#asignacion_').hide();
    $('#numeroLinea_').val(0)
    GetProductos();
    GetVendedores();
});

var productosArray = [];

function GetProductos() {

    productosArray = []

    $.ajax({
        type: "GET",
        url: urlGetProductos,
        datatype: "json",
        success: function (data) {
            $('#lstArticulo').empty();
            $('#lstArticulo').append('<option value="-1" disabled selected>Select article...</option>');
            $.each(data, function (index, item) {
                $('#lstArticulo').append("<option value=\"" + item.id + "\">" + item.nombreProducto + " - " + item.presentacion + "</option>");
                productosArray.push(item.nombreProducto + " - " + item.presentacion);
            });
        }
    });

    return false;
}


function GetVendedores() {

    $.ajax({
        type: "GET",
        url: urlGetVendedor,
        datatype: "json",
        success: function (data) {
            $('#vendedor').empty();
            $('#vendedor').append('<option value="-1" disabled selected>Select seller...</option>');
            $.each(data, function (index, item) {
                $('#vendedor').append("<option value=\"" + item.id + "\">" + item.nombre + " " + item.apellido + "</option>");
            });
        }
    });

    return false;
}

function GetStock() {
    var id = $('#lstArticulo').val();
    GetExistenciaArticuloBodega_(id);
}

function GetExistenciaArticuloBodega_(id) {
    
    $.ajax({
        type: "GET",
        url: urlGetStockProductoBodega,
        data: { idArticulo: id },
        datatype: "json",
        success: function (data) {
            var cantidad = $('#cantidad').val();
            if (data.cantidad < cantidad) {
                toastr.warning("They only exist in stock: " + data.cantidad);
            }
        }
    });
    console.log(' ');
}


var lineasArray = [];

function AddLinea() {
    var vendedor = $("#vendedor option:selected").text();
    var vendedorId = $('#vendedor').val()
    var articulo = $("#lstArticulo option:selected").text();
    var articuloId = $('#lstArticulo').val();
    var cantidad = $('#cantidad').val();
    var numero = parseInt($('#numeroLinea_').val());



    if ( articuloId === '' || cantidad === '' || vendedorId === '') {
        toastr.warning("All fields are required");
        return false;
    }


    let ln = `<tr id='r${numero}' >
                  <td style="display:none;"> ${numero} </td>
                  <td id='r${numero}1' > ${vendedor} </td>
                  <td id='r${numero}1' > ${vendedorId} </td>
                  <td id='r${numero}2' > ${articulo} </td>
                  <td id='r${numero}2' > ${articuloId} </td>
                  <td id='r${numero}3' > ${cantidad} </td>
                  <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="RemoveLinea(${numero})">Delete</a></td>
                  </tr>`;

    $('#tablaLineas  tr:last').after(ln);
    AddLineaArray('r' + numero);
    numero = numero + 1;
    $('#numeroLinea_').val(numero);

    $('#articulo').val('')
    $('#cantidad').val('');
    $('#vendedor').val('');
}

function RemoveLinea(row) {
    RemoveLineaArray('r' + row);
    $("#r" + row).remove();
    var number = parseInt($('#numeroLinea_').val());
    number = number - 1;
    $('#numeroLinea_').val(number);
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


