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
            { "data": "id", "with": "10%" , "title": "id" },
            { "data": "fechaRegistroEmpresa", "with": "10%" },
            { "data": "razonSocial", "with": "10%" },
            { "data": "rfc", "with": "10%" },
            { "data": "sucursal", "with": "10%" },
            { "data": "idEmpleado", "with": "10%" },
            { "data": "nombre", "with": "10%" },
            { "data": "paterno", "with": "10%" },
            { "data": "materno", "with": "10%" },
            { "data": "idviaje", "with": "10%" }            
        ]
    });
}