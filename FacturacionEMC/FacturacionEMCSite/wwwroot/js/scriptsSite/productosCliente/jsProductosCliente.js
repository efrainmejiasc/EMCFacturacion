var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});


function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    console.log(cultureInfo);
    GetCategorias();
}

function BuscarProducto() {

    var strProducto = $("#strBusqueda option:selected").text();

    if (strProducto == '')
        return false;

    var nombre = cultureInfo === 'es-ES' ? "Nombre" : "Name";
    var categoria = cultureInfo === 'es-ES' ? "Categoria" : "Category";
    var tamaño = cultureInfo === 'es-ES' ? "Tamaño" : "Size";
    var peso = cultureInfo === 'es-ES' ? "Peso" : "Weight";
    var descripcion = cultureInfo === 'es-ES' ? "Descripcion" : "Description";
    var precio = cultureInfo === 'es-ES' ? "Precio" : "Price";
    var ids = [];
    var coin = cultureInfo === 'es-ES' ? " Bs" : " $";

    $.ajax({
        url: urlGetInfoProducto,
        data: {strProducto: strProducto},
        type: "GET",
        timeout: 0,
        success: function (data) {
            console.log(data)
            if (data.length > 0) {
                $('#imgns').empty();
                $.each(data, function (index, item) {
                    if (!ids.includes(item.id)) {
                        ids.push(item.id); 
                        var _id = item.id;
                        var car = `<div class="card-body darkdiv">
                                       <div class=col-md-12 darkdiv">
                                            <span style=color:navajowhite;> ${nombre}: </span>     <span style=color:navajowhite;> ${item.nombre} </span><br>
                                            <span style=color:navajowhite;> ${categoria}: </span>  <span style=color:navajowhite;> ${item.categoria} </span><br>
                                            <span style=color:navajowhite;> ${precio}: </span>     <span style=color:red;> ${item.precio} ${coin} </span><br>
                                            <span style=color:navajowhite;> ${tamaño}: </span>     <span style=color:navajowhite;> ${item.tamaño} </span><br>
                                            <span style=color:navajowhite;> ${peso}: </span>       <span style=color:navajowhite;> ${item.peso} </span><br>
                                            <span style=color:navajowhite;> ${descripcion}:</span> <span style=color:mediumvioletred;> ${item.descripcion}</span><br>
                                        </div>
                                    </div>`;
                        $('#imgns').append(car);
                        $.each(item.infoImg, function (index, itemn) {
                            let img = `<div class="card-body darkdiv"> 
                                          <div class = "col-md-12">
                                              <img  id='${itemn.identificador}' src='${itemn.strBase64}' class=img-thumbnail style=top:50.6667px;opacity: 0;width:200px;height:200px;border:none;max-width:none;max-height:none; onClick=ImgZoom('${itemn.strBase64}') />
                                          </div>
                                       </div>
                                      <br><hr>`;
                            $('#imgns').append(img);
                        });
                    }
                });

            }
            else {
                $('#imgns').empty();
                var messaje = cultureInfo === 'es-ES' ? "Transaccion fallida, No existe " + strProducto : "Failure transaction, Don't find " + strProducto ;
                toastr.warning(messaje);
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


function GetCategorias() {

    var articulo = cultureInfo == 'en-US' ? 'Select article...' : 'Seleccione articulo...';

    $.ajax({
        type: "GET",
        url: urlGetCategoriaDescripcion,
        datatype: "json",
        success: function (data) {
            console.log(data);
            $('#strBusqueda').empty();
            $('#strBusqueda').append('<option value="-1" disabled selected>' + articulo + '</option>');
            $.each(data, function (index, item) {
                $('#strBusqueda').append("<option value=\"" + item + "\">" + item + "</option>");
            });
        }
    });

    return false;
}

