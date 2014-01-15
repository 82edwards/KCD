var passwordAttempt = 0;
$(document).ready(function () {
    $('#SignIn').click(function () {
        $.ajax({
            type: "POST",
            url: "../Security/Login",
            data: { userName: $('#LoginUserName').val(), password: $('#LoginPassword').val() },
            cache: false,
            complete: function (result) {
                var test = JSON.parse(result.responseJSON);
                if (test.Success == "True") {
                    $('#LoginBox').slideToggle(400);
                    LoggedIn();
                } else {
                    passwordAttempt++;
                    if (passwordAttempt == 1)
                        alert('Wrong password Sherlock.  Do you need help typing?');
                    else if (passwordAttempt == 2)
                        alert('Seriously, what is wrong with you.  What are you thinking?');
                    else if (passwordAttempt == 3)
                        alert('One more try.  Then I am going to use the ban hammer.  You do not want to test me!!!');
                    else
                        alert('You suck.');
                }
            }
        });
    });

    $('#CreateAnAccount').click(function () {
        window.location.replace("../Security/CreateAnAccount");
    });
});

function LoggedIn() {
    $('#login').hide();
    $('#logout').show();
    $('#LoginUserName').val('');
    $('#LoginPassword').val('');
    $('#LoginBox').slideToggle(400);
}

function LoggedOut() {
    $('#login').show();
    $('#logout').hide();
    $('#LoginUserName').val('');
    $('#LoginPassword').val('');
}