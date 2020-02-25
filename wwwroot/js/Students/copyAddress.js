$("#copyAddress").on("click", () => {
    $("#Domicile_town").val($("#PlaceOfResidence_town").val());
    $("#Domicile_street").val($("#PlaceOfResidence_street").val());
    $("#Domicile_zipCode").val($("#PlaceOfResidence_zipCode").val());
});