$(document).ready(function () {
    $('#LoginBox').hide();

    $('#login').click(function () {
        $('#LoginBox').slideToggle(400);
        return false;
    });
});