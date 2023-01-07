var cultureInfo = '';

$(document).ready(function () {
    console.log("ready!");
    setTimeout(DocumentoListo, 2000);
});


function DocumentoListo() {
    var obje = $(document).find('#cultureInfo').prop('disabled', true);
    cultureInfo = $('#cultureInfo').val();
    console.log(cultureInfo);
    GetInfoImagenes();
}

function GetInfoImagenes() {

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
                      <td> ${item.descripcion} </td>
                      <td> ${item.categoria} </td>
                      <td> <img  id='${item.id}' src='${item.strBase64}'  class="img-fluid img-thumbnail" style="width:70%; min-width:70px; min-height:50px; height:auto;"/></td>
                      <td>  <input type="button" onclick="Editar();" class="btn btn-warning" value="Editar" /> </td>
                      <td>  <input type="button" onclick="Eliminar();" class="btn btn-danger" value="Eliminar"  /> </td>
                      </tr>`;
                    $('#tablaImg tbody').append(tr);
                });
               // setTimeout(InicializarDataTable, 1000);
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