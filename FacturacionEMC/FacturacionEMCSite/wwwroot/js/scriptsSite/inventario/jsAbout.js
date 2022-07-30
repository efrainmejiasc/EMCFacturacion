var cultureInfo = '';

$(document).ready(function () {
    console.log('ready!');
    cultureInfo = $('#cultureInfo').val();
    $('#asignacion_').hide();
    $('#numeroLinea_').val(0)
    GetProductos();
    GetVendedores();
    GetUnidadesMedida();
});

var productosArray = [];

function GetProductos() {

    var seleccion = cultureInfo == 'en-US' ? 'Select article...' : 'Seleccione articulo...';
    productosArray = []

    $.ajax({
        type: "GET",
        url: urlGetProductos,
        datatype: "json",
        success: function (data) {
            $('#lstArticulo').empty();
            $('#lstArticulo').append('<option value="-1" disabled selected>' + seleccion + '</option>');
            $.each(data, function (index, item) {
                $('#lstArticulo').append("<option value=\"" + item.id + "\">" + item.nombreProducto + " - " + item.presentacion + "</option>");
                productosArray.push(item.nombreProducto + " - " + item.presentacion);
            });
        }
    });

    return false;
}


function GetVendedores() {

    var seleccion = cultureInfo == 'en-US' ? 'Select seller...' : 'Seleccione vendedor...';

    $.ajax({
        type: "GET",
        url: urlGetVendedor,
        datatype: "json",
        success: function (data) {
            $('#vendedor').empty();
            $('#vendedor').append('<option value="-1" disabled selected>' + seleccion + '</option>');
            $.each(data, function (index, item) {
                $('#vendedor').append("<option value=\"" + item.id + "\">" + item.nombre + " " + item.apellido + "</option>");
            });
        }
    });

    return false;
}

function GetUnidadesMedida() {

    var seleccion = cultureInfo == 'en-US' ? 'Select unit...' : 'Select unit...';

    $.ajax({
        type: "GET",
        url: urlGetUnidadesMedida,
        datatype: "json",
        success: function (data) {
            $('#unidad').empty();
            $('#unidad').append('<option value="-1" disabled selected>' + seleccion + '</option>');
            $.each(data, function (index, item) {
                $('#unidad').append("<option value=\"" + item.id + "\">" + item.unidad + "</option>");
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
                if(cultureInfo == 'en-US')
                    toastr.warning("They only exist in stock: " + data.cantidad);
                else if (cultureInfo == 'es-ES')
                    toastr.warning("Solo existe en stock: " + data.cantidad);
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
    var strUnidad = $("#unidad option:selected").text();
    var unidad = $('#unidad').val()
    var numero = parseInt($('#numeroLinea_').val());



    if ( articuloId === '' || cantidad === '' || vendedorId === ''|| unidad ==='') {
        toastr.warning("All fields are required");
        return false;
    }


    let ln = `<tr id='r${numero}' >
                  <td style="display:none;"> ${numero} </td>
                  <td id='r${numero}1' > ${vendedor} </td>
                  <td id='r${numero}2' style="display:none;" > ${vendedorId} </td>
                  <td id='r${numero}3' > ${articulo} </td>
                  <td id='r${numero}4' style="display:none;"> ${articuloId} </td>
                  <td id='r${numero}5' > ${cantidad} </td>
                  <td id='r${numero}6' style="display:none;"> ${unidad} </td>
                  <td id='r${numero}7' > ${strUnidad} </td>
                  <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="RemoveLinea(${numero})">Delete</a></td>
                  </tr>`;

    $('#tablaLineas  tr:last').after(ln);
    AddLineaArray('r' + numero);
    numero = numero + 1;
    $('#numeroLinea_').val(numero);
    //$('#vendedor').val('-1');
    $('#lstArticulo').val('-1')
    $('#cantidad').val('');
    $('#unidad').val('-1');
}


function GuardarAsignacion() {
    var StockTransitoDTO = new Array();
    var nfilas = $("#tablaLineas").find("tr");


    for (var i = 1; i < nfilas.length; i++) {
        var celdas = $(nfilas[i]).find("td");
        var x = {};
        x.Linea = parseInt(i);
        x.NombreVendedor = $(celdas[1]).text();
        x.IdVendedor = parseInt($(celdas[2]).text());
        x.NombreArticulo = $(celdas[3]).text();
        x.IdArticulo = parseInt($(celdas[4]).text());
        x.Cantidad = parseFloat($(celdas[5]).text());
        x.Unidad = parseInt($(celdas[6]).text());
        x.StrUnidad = $(celdas[7]).text();
        x.IdUsuario = 0;
        x.Activo = true;

        StockTransitoDTO.push(x);
    }

    $.ajax({
        type: "POST",
        url: urlGuardarAsignaciones,
        data: { asignaciones: JSON.stringify(StockTransitoDTO) },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                if (cultureInfo == 'en-US')
                    toastr.success("Assigned saved successfully.");
                else if (cultureInfo == 'es-ES')
                    toastr.success("Asignacion guardada exitosamente.");
              
                setTimeout(RecargarPagina, 4000);
            }
            else
                toastr.error("Unexpected error");
        }
    });

    return false;
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

function RecargarPagina() {
    location.reload(true);
}

