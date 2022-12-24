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
    var ids =  [];
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
                        var car = `<hr /><div class=col-md-6>
                              <span> ${nombre}: </span> <span> ${item.nombre} </span><br>
                              <span> ${categoria}: </span> <span> ${item.categoria} </span><br>
                              <span> ${tamaño}: </span> <span> ${item.tamaño} </span><br>
                              <span> ${peso}: </span> <span> ${item.peso} </span><br>
                              <span> ${descripcion}: </span> <span> ${item.descripcion}</span><br><br>
                              </div>  <hr />`;
                        $('#imgns').append(car);
                        $.each(item.infoImg, function (index, itemn) {
                            let img = `<div class=col-md-6>
                                 <img  id='${itemn.identificador}' src='${itemn.strBase64}' class=img-thumbnail style='height:150px;weight=130px;' />
                              </div>`;
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

