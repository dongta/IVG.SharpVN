$(function () {
    function ShowToastr() {
        toastr.success("Record Created", "Successfully Created",);
    };
    $(document).ready(function () {
        $("select").select2({
            theme: "classic",
            width: 'resolve'
        });
        if ($(`input[name="id"]`).val() == "00000000-0000-0000-0000-000000000000") {
            //$(`input[type="date"]`).each(function () {
            //    SetDateNow($(this));
            //});
            SetDateNow($(`input[name="ngayTiepNhan"`));
            SetDateNow($(`input[name="ngayTaoPhieu"`));
        }
        if (formDisable) {
            $("form[name='frmCaseRequest'] :input").prop("disabled", true);
        }
    });

    function SetDateNow($selector) {
        var now = new Date();

        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);
        var hour = ("0" + (now.getHours())).slice(-2);
        var minute = ("0" + (now.getMinutes())).slice(-2);
        var second = ("0" + (now.getSeconds())).slice(-2);
        var milisecond = ("0" + (now.getMilliseconds())).slice(-2);

        //var today = now.getFullYear() + "-" + (month) + "-" + (day) + "T" + hour+":";
        //var timeFull = `${now.getFullYear()}-${(month)}-${(day)}T${hour}:${minute}:${second}.${milisecond}`
        //var dateTime = `${now.getFullYear()}-${(month)}-${(day)}T${hour}:${minute}`;
        var dateTime = `${now.getFullYear()}-${(month)}-${(day)}`;

        $selector.val(dateTime);
    }

    $("form[name='frmCaseRequest']").validate({
        rules: {
            diaChi: {
                required: true,
            },
            soDienThoai: "required",
            tenKhachHang: "required",
            hienTuong: 'required',
            tinhTP: 'required',
            quanHuyen: 'required',
            phuongXa: 'required',
            sanPham: 'required',
            email: {
                email:true
            }
        },
        messages: {
            diaChi: "Vui lòng nhập địa chỉ.",
            soDienThoai: "Vui lòng nhập số điện thoại.",
            tenKhachHang: "Vui lòng nhập tên khách hàng.",
            hienTuong: 'Vui lòng chọn hiện tượng.',
            tinhTP: 'Vui lòng chọn Tỉnh/thành phố.',
            quanHuyen: 'Vui lòng chọn Quận/huyện.',
            phuongXa: 'Vui lòng chọn Phường/xã.',
            sanPham: 'Vui lòng chọn sản phẩm.',
        },
        submitHandler: function (form) {
            console.log(`form`, form);
            var formArray = $(form).serializeArray();
            var formData = {};
            $.map(formArray, function (n, i) {
                formData[n['name']] = n['value'];
            });
            console.log(formData);
            $.ajax({
                method: 'post',
                cache: false,
                url: '/Dealer/AddRequest',
                data: formData,
                dataType: 'json',
                success: (res) => {
                    console.log(`result`, res);
                    console.log(res);
                    $(`input[name="maPhieu"]`).val(res?.MaPhieu);
                    $(`input[name="khachHangId"]`).val(res?.KhachHangId);
                    $(`input[name="id"]`).val(res?.Id);
                    if ($(`input[name="id"]`).val() == "00000000-0000-0000-0000-000000000000") {
                        toastr.success("Successfully Created","Record Created",);
                    } else {
                        toastr.success("Successfully Updated","Record Updated", );
                    }
                },
                error: (err) => {
                    console.log(`err`, err);
                    toastr.error(err.statusText, "Error");
                },
            });
        }
    });


    //name="ASC"
    $(document).off(`change`, `select[name="ASC"]`).on("change", `select[name="ASC"]`, () => {
        let ascId = $(`select[name="ASC"]`).val();
        $.ajax({
            method: 'get',
            cache: false,
            url: '/api/Combobox/GetKyThuatVienByTrungTamId',
            data: { id: ascId },
            dataType: 'json',
            success: (data) => {
                var options = `<option value="">Chọn kỹ thuật viên</option>`
                data?.forEach((item, index) => {
                    options += `<option value="${item.id}">${item.displayName}</option>`
                });
                $(`select[name="technician"]`).html(options).prop('disabled', false)
            },
        });
    });

    //Tỉnh thành onchange
    $(document).off(`change`, `select[name="tinhTP"]`).on("change", `select[name="tinhTP"]`, () => {
        let tinhThanhId = $(`select[name="tinhTP"]`).val();
        $.ajax({
            method: 'get',
            cache: false,
            url: '/api/Combobox/GetQuanHuyenComboxByTinhThanhId',
            data: { id: tinhThanhId },
            dataType: 'json',
            success: (data) => {
                var options = `<option value="">Chọn quận/huyện</option>`
                data?.forEach((item, index) => {
                    options += `<option value="${item.id}">${item.displayName}</option>`
                });
                $(`select[name="quanHuyen"]`).html(options).prop('disabled', false)
            },
        });
        $(`select[name="phuongXa"]`).val('').trigger('change').prop('disabled', true);
    });
    //Quận huyện change
    $(document).off(`change`, `select[name="quanHuyen"]`).on("change", `select[name="quanHuyen"]`, () => {
        let quanHuyenId = $(`select[name="quanHuyen"]`).val();
        $.ajax({
            method: 'get',
            cache: false,
            url: '/api/Combobox/GetPhuongXaComboxByQuanHuyenId',
            data: { id: quanHuyenId },
            dataType: 'json',
            success: (data) => {
                var options = `<option value="">Chọn phường/xã</option>`
                data?.forEach((item, index) => {
                    options += `<option value="${item.id}">${item.displayName}</option>`
                });
                $(`select[name="phuongXa"]`).html(options).prop('disabled', false)
            },
        });
    });
    //select change
    $(`select`).on('select2:select', function (e) {
        $('form').valid();
    });
});