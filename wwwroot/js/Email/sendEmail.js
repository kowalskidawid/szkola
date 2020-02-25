$("#sendEmail").on("click", () => {
    let emailValue = emailTemplate.getData();
    let selectedPerson = $(`#studentsList input[type="checkbox"]:checked`).length + $(`#teachersList input[type="checkbox"]:checked`).length
    let errorFlag = false;

    if (selectedPerson === 0) {
        $("#emptyRecipient").removeClass("d-none");
        errorFlag = true;
    }

    if (emailValue.length === 0) {
        $("#emptyContent").removeClass("d-none");
        errorFlag = true;
    }

    if (!errorFlag) {
        dataToSend = new FormData;
        dataToSend.append('content', emailValue);
        dataToSend.append('subject', $("#subject").val());
        dataToSend.append('attach', $("#attachment"))
    }
});