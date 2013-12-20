$(document).ready(function () {

    $('#SignIn').click(function () {
        $.ajax({
            type: "POST",
            url: "../Security/Login",
            data: { userName: 'test', password: 'pass' },
            cache: false,
            complete: function (result) {
                if (result) {
                    $('#LoginBox').slideToggle(400);
                    $('#login').text('Log Out');
                } else {

                }
            }
        });
    });

    $('#CreateAnAccount').click(function () {
        window.location.replace("../Security/CreateAnAccount");
    });
});