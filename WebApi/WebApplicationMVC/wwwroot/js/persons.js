var DataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    DataTable = $('#PersonsT').DataTable({
        "ajax": {
            "url": "/Persons/GetAllPersons",
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
            "info": "Página _PAGE_ de _PAGES_",
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
        "columns":[
            { "data": "firstName", "with": "30%", "title": "APaterno" },
            { "data": "lastName", "with": "30%", "title": "AMaterno" },
            { "data": "name", "with": "30%", "title": "Nombre" },
            { "data": "rfc", "with": "20%", "title": "RFC" },
            { "data": "birthDate", "with": "20%", "title": "Fecha nacimiento"               
            },            
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Persons/EditPerson/${data}" class="btn btn-success text-white" style="cursor-pointer;">Editar</a>
                            &nbsp
                            <a onclick=Delete("/Persons/DeletePerson/${data}") class="btn btn-danger text-white" style="cursor-pointer;">Eliminar</a>
                            </div>`
                },"with": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "¿Confirma eliminación de registro?",
        text: "Esta acción no podra ser revertida",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        DataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}