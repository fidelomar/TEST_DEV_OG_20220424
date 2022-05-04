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
        "dom": 'Bfrtip',
        "buttons": [
            {
                extend: 'csvHtml5',
                text: 'Exportar',
                exportOptions: {
                    modifier: {
                        search: 'none'
                    }
                }
            }
        ],
        "pageLength": 20,
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "zeroRecords": "sin resultados -",
            "info": "Mostrar página _PAGE_ de _PAGES_",
            "infoEmpty": "No disponible",
            "infoFiltered": "(filtro de _MAX_ total registros)",            
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
        },
        "columns": [
            { "data": "idCliente", "with": "10%" , "title": "id"},
            { "data": "fechaRegistroEmpresa", "with": "10%", "title": "Fecha registro"},
            { "data": "razonSocial", "with": "10%", "title": "Razón Social" },
            { "data": "rfc", "with": "10%", "title": "RFC" },
            { "data": "sucursal", "with": "10%", "title": "Sucursal" },
            { "data": "idEmpleado", "with": "10%", "title": "Id Empleado" },
            { "data": "nombre", "with": "10%", "title": "Nombre"},
            { "data": "paterno", "with": "10%", "title": "Paterno" },
            { "data": "materno", "with": "10%", "title": "Materno" },
            { "data": "idViaje", "with": "10%", "title": "Id Viaje" }
        ]
    });
}