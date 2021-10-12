
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
    var numero = parseInt( $('#numeroLinea_').val());
    var articulo = $('#articulo').val();
    var unidad = $('#unidad').val();
    var descripcion = $('#descripcion').val();
    var cantidad = $('#cantidad').val();
    var precio = $('#precio').val();
    var subTotalLinea = $('#subTotalLinea').val();

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
}

function RemoveLinea(row) {
    RemoveLineaArray('r' + row);
    $("#r" + row).remove();
    var number = parseInt($('#numeroLinea_').val());
    number = number - 1 ;
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



function SubtotalLinea() {
    var cantidad = $('#cantidad').val();
    var precio = $('#precio').val();

    var subtotal = cantidad * precio;
    $('#subTotalLinea').val(subtotal);
}


function SetTotalesTabla() {

    var linea = 0;
    var articulo = '';
    var descripcion = '';
    var cantidad = 0;
    var unidad = '';
    var precio = 0;
    var subtotal = 0;

    //devulve las filas del body de tu tabla segun el ejemplo que brindaste
    var nfilas = $("#tablaLinease").find("tr");
    //Recorre las filas 1 a 1
    for (i = 0; i <= nfilas.length; i++) {
        //devolverá las celdas de una fila
        var celdas = $(nfilas[i]).find("td");
        linea = i + 1;
        articulo = $(celdas[1]).text();
        descripcion = $(celdas[2]).text();
        cantidad = $(celdas[3]).text();
        unidad = $(celdas[4]).text();
        precio = $(celdas[5]).text();
        subTotal = $(celdas[6]).text();

        console.log(linea + ' ' + articulo + ' ' + descripcion + ' ' + cantidad + ' ' + unidad + ' ' + precio + ' ' +  subtotal);
    }

}



function Guardar() {
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

    console.log(porFila);*/

    var linea = 0;
    var articulo = '';
    var descripcion = '';
    var cantidad = 0;
    var unidad = '';
    var precio = 0;
    var subtotal = 0;

    //devulve las filas del body de tu tabla segun el ejemplo que brindaste
    var nfilas = $("#tablaLineas").find("tr");
    console.log(nfilas);
    //Recorre las filas 1 a 1
    for (var i = 1; i < nfilas.length ; i++) {
        //devolverá las celdas de una fila
        var celdas = $(nfilas[i]).find("td");
        linea = i ;
        articulo = $(celdas[1]).text();
        descripcion = $(celdas[2]).text();
        cantidad = $(celdas[3]).text();
        unidad = $(celdas[4]).text();
        precio = $(celdas[5]).text();
        subtotal = $(celdas[6]).text();

        console.log(linea + ' -' + articulo + ' -' + descripcion + ' -' + cantidad + '- ' + unidad + '- ' + precio + '- ' + subtotal);
    }
}





