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
                      <td>  <input type="button" onclick="SetEditar(${item.id},'${item.nombre}','${item.categoria}','${item.precio}' ,'${item.peso}','${item.tamaño}','${item.descripcion}' );" class="btn btn-warning" value='${editar}'    style="width:125px;" /> </td>
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

function SetEditar(id, nombre, categoria, precio, peso, tamaño, descripcion) {
    $('#_idArticulo').val(id);
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

function Editar() {
    var id = $('#_idArticulo').val();
    var nombreArticulo = $('#_nombreArticulo').val();
    var categoriaArticulo = $('#_categoriaArticulo').val();
    var precioArticulo= $('#_precioArticulo').val();
    var pesoArticulo = $('#_pesoArticulo').val();
    var tamañoArticulo = $('#_tamañoArticulo').val();
    var descripcionArticulo = $('#_descripcionArticulo').val();
    var message = '';

    if (id === '' || nombreArticulo === '' || categoriaArticulo === '' || precioArticulo <= 0
        || pesoArticulo === '' || tamañoArticulo === '' || descripcionArticulo === '')
    {
        message = cultureInfo === 'es-ES' ? "Todos los campos (*) son requeridos" : "All fields (*) are required";
        toastr.warning(message);
        return false;
    }

    var productManagerImgDTO = {
        Id: id,
        Nombre: nombreArticulo,
        Categoria: categoriaArticulo,
        Peso: pesoArticulo,
        Tamaño: tamañoArticulo,
        Descripcion: descripcionArticulo,
        Precio: precioArticulo,
        NombresImg: null,
        Identidades: null
    };

    $.ajax({
        url: urlEditImgProduct,
        data: JSON.stringify(productManagerImgDTO),
        contentType: 'application/json',
        type: "POST",
        timeout: 0,
        success: function (data) {
            if (data.estatus) {
                message = cultureInfo === 'es-ES' ? "Transaccion exitosa" : "Succes transaction";
                CloseEditar();
                toastr.success(message);
                setTimeout(RecargarPagina, 2500);
            }
            else {
                message = cultureInfo === 'es-ES' ? "Transaccion fallida" : "Failure transaction";
                toastr.error(message);
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            toastr.error('ERROR INESPERADO: ' + textStatus + ' ' + jqXHR + ' ' + errorThrown);
        }
    });

    return false;

}

function Eliminar(id) {
    var message = '';

    if (id === '' || id <= 0) {
        message = cultureInfo === 'es-ES' ? "Todos los campos (*) son requeridos" : "All fields (*) are required";
        toastr.warning(message);
        return false;
    }

    $.ajax({
        url: urlDeleteImgProduct,
        data: {id: id},
        type: "POST",
        timeout: 0,
        success: function (data) {
            if (data.estatus) {
                message = cultureInfo === 'es-ES' ? "Transaccion exitosa" : "Succes transaction";
                CloseEditar();
                toastr.success(message);
                setTimeout(RecargarPagina, 2500);
            }
            else {
                message = cultureInfo === 'es-ES' ? "Transaccion fallida" : "Failure transaction";
                toastr.error(message);
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            toastr.error('ERROR INESPERADO: ' + textStatus + ' ' + jqXHR + ' ' + errorThrown);
        }
    });

    return false;
}


function SetCategoriaArticulo() {

    var categoria = $("#lstArticulo option:selected").text();
    $('#_categoriaArticulo').val(categoria);

}

function RecargarPagina() {
    location.reload();
}