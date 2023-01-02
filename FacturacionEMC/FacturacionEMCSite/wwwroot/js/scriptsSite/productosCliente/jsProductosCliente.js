var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});


function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    console.log(cultureInfo);
}

function BuscarProducto() {

    var strProducto = $('#strBusqueda').val();

    if (strProducto == '')
        return false;

    var nombre = cultureInfo === 'es-ES' ? "Nombre" : "Name";
    var categoria = cultureInfo === 'es-ES' ? "Categoria" : "Category";
    var tamaño = cultureInfo === 'es-ES' ? "Tamaño" : "Size";
    var peso = cultureInfo === 'es-ES' ? "Peso" : "Weight";
    var descripcion = cultureInfo === 'es-ES' ? "Descripcion" : "Description";
    var precio = cultureInfo === 'es-ES' ? "Precio" : "Price";
    var ids = [];

    $.ajax({
        url: urlGetInfoProducto,
        data: {strProducto: strProducto},
        type: "GET",
        timeout: 0,
        success: function (data) {
            if (data != null) {
                console.log(data)
                $('#imgns').empty();
                $.each(data, function (index, item) {
                    if (!ids.includes(item.id)) {
                        ids.push(item.id);
                        var _id = item.id;
                        var car = `<div class=card-body><div class=col-md-12>
                              <span> ${nombre}: </span> <span> ${item.nombre} </span><br>
                              <span> ${categoria}: </span> <span> ${item.categoria} </span><br>
                              <span> ${precio}: </span> <span> ${item.precio} </span><br>
                              <span> ${tamaño}: </span> <span> ${item.tamaño} </span><br>
                              <span> ${peso}: </span> <span> ${item.peso} </span><br>
                              <span> ${descripcion}: </span> <span> ${item.descripcion}</span><br><br>
                              </div> </div>`;
                        $('#imgns').append(car);
                        $.each(item.infoImg, function (index, itemn) {
                            let img = `<div class=card-body> <div class=col-md-12>
                                 <img  id='${itemn.identificador}' src='${itemn.strBase64}' class=img-thumbnail style=top:50.6667px;opacity: 0;width:200px;height:200px;border:none;max-width:none;max-height:none; onClick=ImgZoom('${itemn.strBase64}') />
                              </div> </div><br><br><hr>`;
                            $('#imgns').append(img);
                        });
                    }
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

function ImgZoom(id) {
    console.log(id);
}

