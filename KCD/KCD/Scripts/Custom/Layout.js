$(document).ready(function () {

    $('#LoginBox').slideToggle(400);

    $('#login').click(function () {
        $('#LoginBox').slideToggle(400);
    });

    $('#logout').click(function () {
        LoggedOut();
    });
});