$("#School").on("change", () => {
    $("#Group option").remove();
    let quantityOfClass = $("#School option:selected").attr("data-quantityOfClass");
    for (i = 1; i <= quantityOfClass; i++) $("#Group").append(`<option value = "${i}"> ${i} </option> `);
});