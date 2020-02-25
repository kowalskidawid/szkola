$(".addVariable").on("click", function() {
    let code = $(this).attr("data-variableCode");
    $(".ck-editor__editable p:last-child").append(code);
});