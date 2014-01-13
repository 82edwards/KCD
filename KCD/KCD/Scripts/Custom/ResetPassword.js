$(document).ready(function () {
    $('#ResetPassword').click(function () {
        if ($('#NewPassword').val() == $('#ConfirmPassword').val()) {
            $.ajax({
                type: "POST",
                url: "../Security/ResetPassword",
                data: { userName: $('#ResetUserName').val(), existingPassword: $('#CurrentPassword').val(), newPassword: $('#NewPassword').val() },
                cache: false,
                complete: function (result) {
                    
                    $('#ResetUserName').val('');
                    $('#CurrentPassword').val('');
                    $('#NewPassword').val('');
                    $('#ConfirmPassword').val('');
                }
            });
        } else {
            alert('Passwords do not match.');
        }
    });
});