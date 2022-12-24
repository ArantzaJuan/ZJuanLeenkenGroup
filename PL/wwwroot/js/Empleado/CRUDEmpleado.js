
$(document).ready(function () {  
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7208/api/Empleado/',
        success: function (result) { //200 OK 
            $('#tblEmpleado tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + "<td  id='id' class='text-center'>" + empleado.IdEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.NumeroNomina + "</td>"
                    + "<td class='text-center'>" + empleado.Nombre + "</td>"
                    + "<td class='text-center'>" + empleado.ApellidoPaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.ApellidoMaterno + "</td>"
                    + "<td class='text-center'>" + empleado.EntidadFederativa.IdEntidadFederativa + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#tblEmpleado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};
               



