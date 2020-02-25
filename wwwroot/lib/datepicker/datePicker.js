$(document).ready(() => {
    $("#DateOfBirth").datepicker({
        dateFormat: 'yy-mm-dd',
        maxDate: -5600,
        setDate: -5600,
        });
});