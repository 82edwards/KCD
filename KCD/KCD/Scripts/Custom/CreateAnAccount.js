$(document).ready(function () {
    $('#btnSave').click(function () {
        if ($('#UserName').val() == '' && $('#Password').val() == $('#PasswordConfirmation').val() && $('#Password').val().length > 8) {
            alert('Fix the problems.');
        } else {
            CommitAccount();
        }
    });
});

function CommitAccount() {
    $.ajax({
        type: "POST",
        url: "../Security/CreateAnAccount",
        data: {
            account: {
                UserName: $('#CreateUserName').val(),
                FirstName: $('#FirstName').val(),
                LastName: $('#LastName').val(),
                Password: $('#Password').val(),
                EmailAddress: $('#EmailAddress').val(),
                EmailAddressForSponsors: $('#EmailAddressForSponsors').val(),
                Company: $('#Company').val(),
                CanSendEmails: $('#CanSendEmails').val(),
                CanBeContactedBySponsors: $('#CanBeContactedBySponsors').val()
            }
        },
        cache: false,
        complete: function (result) {

        }
    });
}