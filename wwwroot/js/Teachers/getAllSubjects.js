$(document).ready(() => {
    $.ajax({
        url: "/subjects/ListJson",
        type: "GET",
    })
        .done((subjects) => {
            subjects.forEach((subject, index) => {
                let html = `<div class = "col-sm-12 col-md-4">
                    <input id = "${subject._id}" type = "checkbox" name = "Subjects[${index}]" value = "${subject.abbreviation || ''} - ${subject.name}" class = "form-check-input">
                    <label for = "${subject._id}"> ${subject.abbreviation || ''} - ${subject.name} </label>`;
                $("#subjects").append(html);
            });
        })
        .fail((error) => {
            console.error(error);
        });
    
})