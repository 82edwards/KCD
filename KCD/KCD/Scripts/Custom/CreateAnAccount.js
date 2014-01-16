//$(document).ready(function () {
//    $('#btnSave').click(function () {
//        if ($('#UserName').val() == '' && $('#Password').val() == $('#PasswordConfirmation').val() && $('#Password').val().length > 8) {
//            alert('Fix the problems.');
//        } else {
//            CommitAccount();
//        }
//    });
//});

//function CommitAccount() {
//    var account = {
//        CanBeContactedBySponsors: $('#CanBeContactedBySponsors').val(),
//        CanSendEmails: $('#CanSendEmails').val(),
//        Company: $('#Company').val(),
//        EmailAddress: $('#EmailAddress').val(),
//        EmailAddressForSponsors: $('#EmailAddressForSponsors').val(),
//        FirstName: $('#FirstName').val(),
//        LastName: $('#LastName').val(),
//        Password: $('#Password').val(),
//        UserName: $('#CreateUserName').val()
//    };

//    $.ajax({
//        type: "POST",
//        url: "../Security/CreateAnAccount",
//        data: JSON.stringify(account),
//        dataType: "json",
//        contentType: "application/json; charset=utf-8)",
//        cache: false,
//        complete: function (result) {

//        }
//    });
//}