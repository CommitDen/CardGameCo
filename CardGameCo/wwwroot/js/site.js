
$(document).ready(function () {
    $('.passwordInput').on('input', function () {
        var password = $(this).val();
        var maskedPassword = '';
        for (var i = 0; i < password.length; i++) {
            maskedPassword += '*';
        }
        $(this).val(maskedPassword);
    });

    $('.passwordInput').on('copy paste', function (e) {
        e.preventDefault();
    });
});