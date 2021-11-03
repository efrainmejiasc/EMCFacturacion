$(document).ready(function () {
    console.log("ready!");
    $('#usuario_').hide();
    GetUsuarios();
});

function GetUsuarios() {
    $.ajax({
        type: "GET",
        url: urlGetUsuarios,
        datatype: "json",
        success: function (data) {
            if (data != null) {
                $('#tablaUsuarios tbody tr').remove();
                $.each(data, function (index, item) {
                    let tr = '';
                    var est = item.activo ? 'Activo' : 'Inactivo';
                    var rol = item.idRol == 3 ? 'Seller' : item.idRol == 2 ? 'Client' : 'Manager';
                    if (!item.activo)
                        tr = `<tr>
                      <td style=color:red;> ${est} </td>
                      <td> ${item.nombre} </td>
                      <td> ${item.apellido} </td>
                      <td> ${item.username} </td>
                      <td> ${item.email} </td>
                      <td> ${rol} </td>
                      <td><input type="button" class="btn btn-sm btn-success" onclick="EditEstatus(${item.id} , ${item.idEmpresa} , ${true})" value="Enable" style="width:100px;"></td>
                      <td><input type="button" class="btn btn-sm btn-danger" onclick="DeleteUser(${item.id} , ${item.idEmpresa})" value="Delete" style="width:100px;"></td>
                      </tr>`;
                    else
                        tr = `<tr>
                      <td style=color:green;> ${est} </td>
                      <td> ${item.nombre} </td>
                      <td> ${item.apellido} </td>
                      <td> ${item.username} </td>
                      <td> ${item.email} </td>
                      <td> ${rol} </td>
                      <td><input type="button" class="btn btn-sm btn-warning" onclick="EditEstatus(${item.id}, ${item.idEmpresa} ,${false})" value="Disable" style="width:100px;" ></td>
                      <td><input type="button" class="btn btn-sm btn-danger" onclick="DeleteUser(${item.id} , ${item.idEmpresa})" value="Delete" style="width:100px;"></td>
                      </tr>`;

                    $('#tablaUsuarios tbody').append(tr);
                });
                setTimeout(InicializarDataTable, 1000);
            }
            else {
                $('#tablaUsuarios tbody tr').remove();
            }
        }, error: function (jqXHR, textStatus, errorThrown) {
            $('#tablaUsuarios tbody tr').remove();
        }
    });

    $("#tablaUsuarios").addClass("display compact dt-center");
    return false;
}

function GotoUsers() {
    window.location.href = urlUsuarios;
}


function EditEstatus(id, idEmpresa , estatus) {
    $.ajax({
        type: "POST",
        url: urlEditEstatus,
        data: { Id: id, IdEmpresa: idEmpresa, Activo: estatus },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                GetUsuarios();
                toastr.success("Update status success");
            }
            else {
                toastr.warning("Update status failed");
            }
        }
    });
}

function DeleteUser(id, idEmpresa) {
    $.ajax({
        type: "POST",
        url: urlDeleteUser,
        data: { Id: id, IdEmpresa: idEmpresa },
        datatype: "json",
        success: function (data) {
            if (data.estatus) {
                GetUsuarios();
                toastr.success("Delete user success");
            }
            else {
                toastr.warning("Delete user  failed");
            }
        }
    });
}


function InicializarDataTable() {
    var init = $('#initDataTable').val();

    try {
        if (init === 'no') {
            $('#tablaUsuarios').DataTable({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                "searching": false,
                pagingType: "simple"
            });
            $('#initDataTable').val('si');
        } else {
            $('#tablaUsuarios').DataTable().fnDestroy({
                language: {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                "bInfo": false,
                "lengthChange": false,
                "searching": false,
                pagingType: "simple"
            });
        }
    } catch { console.log(''); }

    $("#tablaUsuarios").addClass("display compact dt-center");
}