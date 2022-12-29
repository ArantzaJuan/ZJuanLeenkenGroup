$(document).ready(function () {
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7208/GetAll',
        success: function (result) { //200 OK 
            $('#tblEmpleado tbody').empty();
            $.each(result.objects, function (i, empleado) {
                var filas =
                    '<tr>'
                  
                    + '<td class="text-center"> <button class="btn btn-warning" onclick="Editar(' + empleado.idEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                    + "<td  id='id' class='text-center' style='display: none'>" + empleado.idEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.numeroNomina + "</td>"
                    + "<td class='text-center'>" + empleado.nombre + "</td>"
                    + "<td class='text-center'>" + empleado.apellidoPaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.apellidoMaterno + "</td>"
                    + "<td class='text-center'>" + empleado.entidadFederativa.idEntidadFederativa + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.idEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#tblEmpleado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.errorMessage);
        }
    });
};

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    
}