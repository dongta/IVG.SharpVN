$(function () {

    //form login
    $("form[name='Login']").validate({
        rules: {
            userName: "required",
            password: "required",
        },
        messages: {
            userName: "Login ID is required.",
            password: "Password is required.",
        },
        submitHandler: function (form) {
            form.submit();
        }
    });


    //form change password
    $.validator.addMethod("confirmNotMatch", function (value, element) {
        return $('input[name="confirmNewPassword"]').val() != $('input[name="newPassword"]').val()
    }, "Password do not match.");

    $("form[name='ChangePassword']").validate({
        rules: {
            CurrentPassword: "required",
            newPassword: "required",
            confirmNewPassword: {
                required: "required",
                equalTo: "#newPassword",
            }
        },
        messages: {
            CurrentPassword: "Current password is required.",
            newPassword: "New password is required.",
            confirmNewPassword: {
                required: "Confirm new password is required.",
                equalTo: "Password do not match."
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });

    //Form forgot password
    $("form[name='forgotPassword']").validate({
        rules: {
            Email: {
                required: true,
                email:true,
            },
            CaptCha: "required",
        },
        messages: {
            Email: "Email is required.",
            CaptCha: "CaptCha code is required.",
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});