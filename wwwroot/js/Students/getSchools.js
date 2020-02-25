$(document).ready(() => {
    $.get("/Schools/ListJson/", (response) => {
        $.get(`/students/getClass/${$("#zid").val()}`, schoolAndClass => {
            console.log(schoolAndClass);
            response.forEach(school => {
                if (school.name != schoolAndClass.school)
                    $("#School").append(`<option value = "${school.name}" data-quantityOfClass = "${school.quantityOfClass}" > ${school.name} </option>`);
                else {
                    $("#School").append(`<option value = "${school.name}" data-quantityOfClass = "${school.quantityOfClass}" selected> ${school.name} </option>`);

                    for (i = 1; i <= school.quantityOfClass; i++) {
                        if (schoolAndClass.group != i) $("#Group").append(`<option value = "${i}"> ${i} </option> `);
                        else $("#Group").append(`<option value = "${i}" selected> ${i} </option> `);
                    }
                }
            });
        });
    });
});