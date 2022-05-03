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
        "columns":[
            { "data": "firstName", "with": "30%" },
            { "data": "lastName", "with": "30%" },
            { "data": "name", "with": "30%" },
            { "data": "rfc", "with": "20%" },
            { "data": "birthDate", "with": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Persons/Edit/$data" class="btn btn-success text-white" style="cursor-pointer;">Editar</a>
                            &nbsp
                            <a onclick=Delete("/Persons/Delete/$data") class="btn btn-danger text-white" style="cursor-pointer;">Eliminar</a>
                            </div>`
                },"with": "20%"
            }
        ]
    });
}
function Delete() {

}