$(document).ready(() => {
    $("table").DataTable({
        "language": {
            "lengthMenu": "Wyświet _MENU_ na stronę",
            "zeroRecords": "Nie znaleziono",
            "info": "Przejdź na stronę _PAGE_ z _PAGES_",
            "infoEmpty": "Nic nie znaleziono",
            "infoFiltered": "(Wyszukiwano z _MAX_ pozycji)",
            "search": "Wyszukaj:",

            "paginate": {
                "previous": "Poprzednia",
                "next": "Następna"
            }
        }
    });
});