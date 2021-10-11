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

    let ln = `<tr id=r${numero}>
                  <td style="display:none;"> ${numero} </td>
                  <td> ${articulo} </td>
                  <td> ${unidad} </td>
                  <td> ${descripcion} </td>
                  <td> ${cantidad} </td>
                  <td> ${precio} </td>
                  <td> ${subTotalLinea} </td>
                  <td><a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="RemoveLinea(${numero})"><small><i class="mdi mdi-delete-forever"></i></small></a></td>
                  </tr>`;

    $('#tablaLineas  tr:last').after(ln);
    AddLineaArray('r' + numero);
    numero = numero + 1;
    $('#numeroLinea_').val(numero);
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
        console.log(lineasArray);
    }
    else {
        return false;
    }
}

function RemoveLineaArray(id) {

    lineasArray.splice(lineasArray.indexOf(id), 1);
    console.log(lineasArray);
}

function Guardar() {
   /* console.log(lineasArray);
    for (var i = 0; i < lineasArray.length; ++i) {
        console.log(lineasArray[i]);
    }

    var html_table_data = "";
    var bRowStarted = true;
    $('#tablaLineas tbody > tr').each(function () {
        $('td', this).each(function () {
            if (html_table_data.length == 0 || bRowStarted == true) {
                html_table_data += $(this).text();
                bRowStarted = false;
            }
            else
                html_table_data += " | " + $(this).text();
        });
        html_table_data += "\n";
        bRowStarted = true;
    });

    alert(html_table_data);*/


    var tabla = document.getElementById('tablaLineas');
    var filas = tabla.rows.length;
    var linea = 0;
    var articulo = '';
    var descripcion = '';
    var unidad = '';
    var descripcion = '';

    for (var i = 0; i < filas; i++)
    {
        tr = tabla.rows[i];
        linea = i + 1;
        articulo = tr.cells[1].innerHTML;
        unidad = tr.cells[2].innerHTML;
        descripcion = tr.cells[3].innerHTML;

        console.log(linea + ' ' + articulo + ' ' + unidad + ' ' + descripcion);
    }    
}





