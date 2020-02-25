$(document).ready(() => {
    $.ajax({
        url: "/subjects/ListJson",
        type: "GET",
    })
        .done((allSubjects) => {
            $.ajax({
                url: `/teachers/getSubjects/${$("input[type='hidden'").val()}`,
                type: "GET"
            })
                .done((learnSubjects) => {
                    allSubjects.forEach((subject, index) => {
                        html = '';
                        if (learnSubjects.indexOf(subject.name) != -1) {
                            html = `<div class = "col-sm-12 col-md-4">
                                <input id = "${subject._id}" type = "checkbox" name = "Subjects[${index}]" value = "${subject.name}" class = "form-check-input" checked>
                                <label for = "${subject._id}"> ${subject.abbreviation || ''} - ${subject.name} </label>`;
                        }
                        else {
                            html = `<div class = "col-sm-12 col-md-4">
                                <input id = "${subject._id}" type = "checkbox" name = "Subjects[${index}]" value = "${subject.name}" class = "form-check-input">
                                <label for = "${subject._id}"> ${subject.abbreviation || ''} - ${subject.name} </label>`;
                        }
                        $("#subjects").append(html);
                    });
                });
        })
        .fail((error) => {
            console.error(error);
        });
    
})