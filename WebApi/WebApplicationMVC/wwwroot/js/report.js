var DataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    DataTable = $('#ReportT').DataTable({
        "ajax": {
            "url": "/Report/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "with": "10%" },
           { "data": "fechaRegistroEmpresa", "with": "10%" },
            { "data": "razonSocial", "with": "10%" },
            { "data": "rfc", "with": "10%" },
            { "data": "sucursal", "with": "10%" },
            { "data": "idEmpleado", "with": "10%" },
            { "data": "nombre", "with": "10%" },
            { "data": "paterno", "with": "10%" },
            { "data": "materno", "with": "10%" },
            { "data": "idviaje", "with": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Persons/EditPerson/${data}" class="btn btn-success text-white" style="cursor-pointer;">Editar</a>
                            &nbsp
                            <a onclick=Delete("/Persons/DeletePerson/${data}") class="btn btn-danger text-white" style="cursor-pointer;">Eliminar</a>
                            </div>`
                }, "with": "20%"
            }
        ]
    });
}