emailTemplate = null;

ClassicEditor
    .create(document.querySelector('#content'))
    .then(editor => {
        emailTemplate = editor;
        editor.editing.view.focus();
    })
    .catch(error => {
        console.error(error);
    });