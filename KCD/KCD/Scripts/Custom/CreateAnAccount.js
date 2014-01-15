$(document).ready(function() {
    $('#btnSave').click(function() {
        if ($('#UserName').val() == '') {
            alert('Please enter a User Name.');
        }
    });
});