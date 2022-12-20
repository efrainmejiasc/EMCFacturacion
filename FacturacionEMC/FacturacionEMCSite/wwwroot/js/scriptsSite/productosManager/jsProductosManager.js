var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});


function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    GetProductos();
    console.log(cultureInfo);
}

function GetProductos() {

    var article = cultureInfo == 'en-US' ? 'Select article...' : 'Seleccione articulo...';

    $.ajax({
        type: "GET",
        url: urlGetProductos,
        datatype: "json",
        success: function (data) {
            productosArray = data;
            $('#lstArticulo').empty();
            $('#lstArticulo').append('<option value="-1" disabled selected>' + article + '</option>');
            $.each(data, function (index, item) {
                $('#lstArticulo').append("<option value=\"" + item.id + "\">" + item.nombreProducto + "</option>");
            });
        }
    });

    return false;
}


function UploadFileMethod() {
    var input = document.getElementById('theFile');
    var files = input.files;

    var nombreArticulo = $('#nombreArticulo').val();
    var categoriaArticulo = $('#lstArticulo').val();
    var pesoArticulo = $('#pesoArticulo').val();
    var tamañoArticulo = $('#tamañoArticulo').val();
    var descripcionArticulo = $('#descripcionArticulo').val();

    if (files.length == 0) {
        toastr.warning("Debe elegir imagenes del articulo");
        return false;
    }

   
    var formData = new FormData();
    for (var i = 0; i < files.length ; i++) {
        formData.append('files', files[i]);
    }


    $.ajax({
        url: urlUploadDataImg,
        data: formData,
        processData: false,
        contentType: false,
        type: "POST",
        timeout: 0,
        success: function (data) {
            console.log(data);
            if (data.estatus) {
                toastr.success("exit");
            }
            else {
                toastr.error("fallo");
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            toastr.error('ERROR INESPERADO: ' + textStatus + ' ' + jqXHR + ' ' + errorThrown);
        }
    });

    return false;
}