$(document).ready(function () {
    $('#ResetPassword').click(function () {
        if (('#NewPassword').val() == ('#ConfirmPassword').val()) {
            $.ajax({
                type: "POST",
                url: "../Security/ResetPassword",
                data: { userName: $('#UserName').val(), existingPassword: $('#CurrentPassword').val(), newPassword: $('#NewPassword').val() },
                cache: false,
                complete: function (result) {

                }
            });
        } else {
            alert('Passwords do not match.');
        }
    });
});