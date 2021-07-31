
$(function () {
    $(document).ready(function () {
        $("select").select2({
            theme: "classic",
            width: 'resolve'
        });
    });

    $("form[name='frmAddUser']").validate({
        rules: {
            userName: {
                required: true,
            },
            displayName: "required",
            email: { required: true, email: true },
            phone: {
                required: true,
            },
            active: 'required',
        },
        messages: {
            userName: "Vui lòng nhập tên đăng nhập.",
            displayName: "Vui lòng nhập họ và tên.",
            email: { required: "Vui lòng nhập email.",email:"Email không đúng định dạng." },
            phone: "Vui lòng nhập số điện thoại.",
            active: 'Vui lòng chọn trạng thái.',
        },
        submitHandler: function (form) {
            console.log(`form`, form);
            var formArray = $(form).serializeArray();
            var formData = {};
            var listRole = [];
            $("form[name='frmAddUser'] input:checkbox:checked").each(function () {
                listRole.push($(this).val());
            });
            $.map(formArray, function (n, i) {
                formData[n['name']] = n['value'];
            });
            formData.listRole = listRole;
            console.log(formData);
            $.ajax({
                method: 'post',
                cache: false,
                url: '/api/admin/createUser',
                data: formData,
                dataType: 'json',
                success: (res) => {
                    console.log(`result`, res);
                    if (res?.status == false) {
                        toastr.error(res.message, "Action failed");
                        return;
                    }
                    $(`input[name="id"]`).val(res?.Id);
                    if ($(`input[name="id"]`).val() == "00000000-0000-0000-0000-000000000000") {
                        toastr.success("Successfully Created", "Record Created",);
                        var href = `${window.location.href}?id=${res.id}`;
                        setTimeout(function () {
                            window.location = href;
                        }, 2000)
                    } else {
                        toastr.success("Successfully Updated", "Record Updated",);                        
                    }
                },
                error: (err) => {
                    console.log(`err`, err);
                    toastr.error(err.statusText, "Error");
                },
            });
        }
    });
});