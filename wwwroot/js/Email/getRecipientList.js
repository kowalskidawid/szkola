$(document).ready(() => {
    $.get("/teachers/getRecipientList")
        .done((response) => {
            $("#teachersList").html(response);
        })
        .fail((error) => {
            console.error(error);
        });

    $.get("/Students/getRecipientList")
        .done((response) => {
            $("#studentsList").html(response);
        })
        .fail((error) => {
            console.error(error);
        });
});