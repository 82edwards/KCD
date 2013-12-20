$(document).ready(function () {

    $('#SignIn').click(function () {
        $.ajax({
            type: "POST",
            url: "../Security/Login",
            data: { userName: 'test', password: 'pass' },
            cache: false,
            complete: function () {
                $('#LoginBox').slideToggle(400);
            }
        });
    });

    $('#CreateAnAccount').click(function () {
        window.location.replace("../Security/CreateAnAccount");
    });
});