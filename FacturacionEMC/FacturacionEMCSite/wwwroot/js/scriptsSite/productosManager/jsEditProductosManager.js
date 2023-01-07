var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    $('#modalEdicion').hide();
    setTimeout(DocumentoListo, 2000);
});


function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    console.log(cultureInfo);
    GetInfoImagenes();
    GetProductos();
}

function GetProductos() {

    var article = cultureInfo == 'en-US' ? 'Select article...' : 'Seleccione articulo...';

    $.ajax({
        type: "GET",
        url: urlGetProductos,
        datatype: "json",
        success: function (data) {
            $('#lstArticulo').empty();
            $('#lstArticulo').append('<option value="-1" disabled selected>' + article + '</option>');
            $.each(data, function (index, item) {
                $('#lstArticulo').append("<option value=\"" + item.id + "\">" + item.nombreProducto + "</option>");
            });
        }
    });

    return false;
}

function GetInfoImagenes() {
    var editar = cultureInfo == 'en-US' ? 'EDIT' : 'EDITAR';
    var eliminar = cultureInfo == 'en-US' ? 'DELETE' : 'ELIMINAR';

    $.ajax({
        type: "GET",
        url: urlGetProductAllImgInfoAsync,
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaImg tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> ${item.id} </td>
                      <td> ${item.nombre} </td>
                      <td> ${item.categoria} </td>
                      <td> <img  id='${item.id}' src='${item.strBase64}'  class="img-fluid img-thumbnail circular--square" style="width:40%; min-width:70px; min-height:25px; height:auto;"/></td>
                      <td>  <input type="button" onclick="Editar(${item.id},'${item.nombre}','${item.categoria}','${item.precio}' ,'${item.peso}','${item.tamaño}','${item.descripcion}' );" class="btn btn-warning" value='${editar}'    style="width:125px;" /> </td>
                      <td>  <input type="button" onclick="Eliminar(${item.id});" class="btn btn-danger" value='${eliminar}'  style="width:125px;" /> </td>
                      </tr>`;
                    $('#tablaImg tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
            }
            else {
                $('#tablaImg tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaImg tbody tr').remove();
        }
    });

    $("#tablaImg").addClass("display compact dt-center");

    return false;
}

function InicializarDataTable() {
    var init = $('#initDataTable').val();

    try {
        if (init === 'no') {
            $('#tablaImg').DataTable({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                pagingType: "simple"
            });
            $('#initDataTable').val('si');
        } else {
            $('#tablaImg').DataTable().fnDestroy({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                pagingType: "simple"
            });
        }
    } catch { console.log(''); }

    $("#tablaImg").addClass("display compact dt-center");
}

function Editar(id, nombre, categoria, precio, peso, tamaño, descripcion) {
    $('#_nombreArticulo').val(nombre);
    $("#lstArticulo option:selected").text(categoria);
    $('#_categoriaArticulo').val(categoria);
    $('#_precioArticulo').val(precio);
    $('#_pesoArticulo').val(peso);
    $('#_tamañoArticulo').val(tamaño);
    $('#_descripcionArticulo').val(descripcion);
    $('#modalEdicion').show();
}

function CloseEditar() {
    $('#modalEdicion').hide();
}

function Eliminar(id) {

}


function SetCategoriaArticulo() {

    var categoria = $("#lstArticulo option:selected").text();
    $('#_categoriaArticulo').val(categoria);

}