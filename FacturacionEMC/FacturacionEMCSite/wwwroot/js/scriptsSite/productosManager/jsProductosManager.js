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
            if (data.estatus) {
                SendParametrosImg(nombreArticulo, categoriaArticulo, pesoArticulo, tamañoArticulo, descripcionArticulo, data.nombres, data.identidades);
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

function SendParametrosImg(nombreArticulo, categoriaArticulo, pesoArticulo, tamañoArticulo, descripcionArticulo, nombreImagenes, identidadesImagenes) {

    var productManagerImgDTO = {
        Id: 0,
        Nombre: nombreArticulo,
        Categoria: categoriaArticulo,
        Peso: pesoArticulo,
        Tamaño: tamañoArticulo,
        Descripcion : descripcionArticulo,
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
                GetImgInfoProductosUploads(data.id);
                var messaje = cultureInfo === 'es-ES' ? "Transaccion exitosa" : "Succes transaction";
                toastr.success(messaje); 
                ResetForm();
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

function GetImgInfoProductosUploads(id) {

    if (id <= 0 || id == '0') {
        return false;
    }

    var nombre = cultureInfo === 'es-ES' ? "Nombre" : "Name";
    var categoria = cultureInfo === 'es-ES' ? "Categoria" : "Category";
    var tamaño = cultureInfo === 'es-ES' ? "Tamaño" : "Size";
    var peso = cultureInfo === 'es-ES' ? "Peso" : "Weight";
    var descripcion = cultureInfo === 'es-ES' ? "Descripcion" : "Description";

    $.ajax({
        url: urlGetImgInfoProductosUploads,
        data: {id: id},
        type: "GET",
        success: function (data) {
            console.log(data);
            if (data != null) {
                $('#imgns').empty();
                var car =  `<div class=col-md-12>
                              <span> ${nombre}: </span> <span> ${data[0].nombre} </span><br>
                              <span> ${categoria}: </span> <span> ${data[0].categoria} </span><br>
                              <span> ${tamaño}: </span> <span> ${data[0].tamaño} </span><br>
                              <span> ${peso}: </span> <span> ${data[0].peso} </span><br>
                              <span> ${descripcion}: </span> <span> ${data[0].descripcion}</span><br><br>
                              </div>  <hr />`;
                $('#imgns').append(car);
                $.each(data, function (index, item) {
                    let img = `<div class=col-md-6>
                                 <img  id='${item.identificador}' src='${item.strBase64}' class=img-thumbnail style='height:250px;weight=200px;' />
                              </div>`;
                    $('#imgns').append(img);
                });
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

function ResetForm() {
     $('#theFile').val('');
     $('#nombreArticulo').val('');
     $('#lstArticulo').val(-1);
     $('#pesoArticulo').val('');
     $('#tamañoArticulo').val('');
     $('#descripcionArticulo').val('');
}