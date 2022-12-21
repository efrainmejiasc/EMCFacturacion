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
    var categoriaArticuloId = $('#lstArticulo').val(); 
    var categoriaArticulo = $("#lstArticulo option:selected").text();
    var pesoArticulo = $('#pesoArticulo').val();
    var tamañoArticulo = $('#tamañoArticulo').val();
    var descripcionArticulo = $('#descripcionArticulo').val();
    var messaje = '';

    if (files.length == 0) {
        messaje = cultureInfo === 'es-ES' ? "Debe seleccionar imagenes" : "You must select images";
        toastr.warning(messaje);
        return false;
    }
    else if (nombreArticulo == '' || descripcionArticulo == '') {
        messaje = cultureInfo === 'es-ES' ? "Todos los campos (*) son requeridos" : "All fields (*) are required";
        toastr.warning(messaje);
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
                SendParametrosImg(nombreArticulo, categoriaArticulo, pesoArticulo, tamañoArticulo, data.nombres, data.identidades );
            }
            else {
                var messaje = cultureInfo === 'es-ES' ? "Transaccion fallida" : "Failure transaction";
                toastr.error(messaje);
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            toastr.error('ERROR INESPERADO: ' + textStatus + ' ' + jqXHR + ' ' + errorThrown);
        }
    });

    return false;
}

function SendParametrosImg(nombreArticulo, categoriaArticulo, pesoArticulo, tamañoArticulo, nombreImagenes, identidadesImagenes) {

    var productManagerImgDTO = {
        Id: 0,
        Nombre: nombreArticulo,
        Categoria: categoriaArticulo,
        Peso: pesoArticulo,
        Tamaño: tamañoArticulo,
        NombresImg: nombreImagenes,
        Identidades: identidadesImagenes
    };

    $.ajax({
        url: urlUploadParametrosImg,
        data: JSON.stringify(productManagerImgDTO),
        contentType: 'application/json',
        type: "POST",
        timeout: 0,
        success: function (data) {
            if (data.estatus) {
                
            }
            else {
                var messaje = cultureInfo === 'es-ES' ? "Transaccion fallida" : "Failure transaction";
                toastr.error(messaje);
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            toastr.error('ERROR INESPERADO: ' + textStatus + ' ' + jqXHR + ' ' + errorThrown);
        }
    });

    return false;
}