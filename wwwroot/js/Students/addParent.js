$("#addParent").on("click", () => {
    $("#secondParent").toggleClass("d-none");
    if ($("#addParent").val() !== "Ukryj") $("#addParent").val("Ukryj");
    else $("#addParent").val("Dodaj rodzica");
});