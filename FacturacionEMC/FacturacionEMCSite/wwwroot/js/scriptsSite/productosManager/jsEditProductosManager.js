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

function GetFacturas() {

    $.ajax({
        type: "GET",
        url: urlGetInfoImg,
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaImg tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = `<tr>
                      <td> ${item.id} </td>
                      <td> ${item.categoria} </td>
                      <td> ${item.descripcion} </td>
                      <td> <img  id='${item.identificador}' src='${item.strBase64}' class=img-thumbnail style='height:80px;weight=80px;' /></td>
                      <td> <input type=button class=btn btn-primary value=EDITAR /> </td>
                      <td> <input type=button class=btn btn-primary value=ELIMINAR /> </td>
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