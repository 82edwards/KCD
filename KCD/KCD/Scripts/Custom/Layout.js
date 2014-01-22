$(document).ready(function () {

    $('#login').click(function () {
        $('#LoginBox').slideToggle(400);
    });

    $('#logout').click(function () {
        LoggedOut();
    });
});

function LoggedOut() {
    $('#login').show();
    $('#logout').hide();
    $('#LoginUserName').val('');
    $('#LoginPassword').val('');

    $.ajax({
        type: "POST",
        url: "../Security/Logout",
        cache: false
    });
}