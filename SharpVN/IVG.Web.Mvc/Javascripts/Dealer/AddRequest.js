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
        if ($(`[name="trangThaiPhieu"]`).val() > 1) {
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


    $.validator.addMethod("validateNgay",
        function (value, element, params) {
            console.log(`value`, value);
            console.log(`param  `, params);
            if (!value) {
                return true;
            }
            if (!$(params).val() && new Date(value) <= new Date($("#currentDate").val())) {
                return true;
            }
            if (!/Invalid|NaN/.test(new Date(value))) {
                return new Date(value) <= new Date($(params).val());
            }

            return isNaN(value) && isNaN($(params).val())
                || (Number(value) <= Number($(params).val()));
        }, 'Ngày không hợp lệ.');

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
            loaiSanPham: 'required',
            sanPham: 'required',
            email: {
                email: true
            },
            ngayMua: {
                validateNgay: "#currentDate"
            },
            ngaySanXuat: {
                validateNgay: "#ngayMua"
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
            loaiSanPham: 'Vui lòng chọn loại sản phẩm.',
            sanPham: 'Vui lòng chọn sản phẩm.',
            ngayMua: {
                validateNgay: "Ngày mua không thể sau ngày hiện tại."
            },
            ngaySanXuat: {
                validateNgay: "Ngày sản xuất không thể sau ngày mua hoặc ngày hiện tại."
            }
        },
        submitHandler: function (form) {
            console.log(`form`, form);
            var formArray = $(form).serializeArray();
            var formData = {};
            $.map(formArray, function (n, i) {
                formData[n['name']] = n['value'];
            });
            console.log(`create object `, formData);
            $.ajax({
                method: 'post',
                cache: false,
                url: '/Dealer/AddRequest',
                data: formData,
                dataType: 'json',
                success: (res) => {
                    console.log(`result`, res);
                    if ($(`input[name="id"]`).val() == "00000000-0000-0000-0000-000000000000") {
                        $(`input[name="requestCode"]`).val(res?.RequestCode);
                        $(`input[name="khachHangId"]`).val(res?.KhachHangId);
                        $(`input[name="id"]`).val(res?.Id);
                        toastr.success("Phiếu yêu cầu đã được tạo", "Thông báo",);
                    } else {
                        toastr.success("Phiếu yêu cầu đã được cập nhật", "Thông báo",);
                    }
                    console.log(`request id `, res?.Id);
                    UploadImages(res?.Id);
                },
                error: (err) => {
                    console.log(`err`, err);
                    toastr.error(err.statusText, "Error");
                },
            });
        }
    });

    function UploadImages(requestId) {
        return new Promise((resolve, reject) => {
            if (window.FormData !== undefined) {

                var fileUpload = $("[name='images']").get(0);
                var files = fileUpload.files;
                var fileData = new FormData();

                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }

                fileData.append('id', requestId);

                $.ajax({
                    url: '/Dealer/UploadFiles',
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: fileData,
                    success: function (result) {
                        console.log(result);
                        resolve();
                    },
                    error: function (err) {
                        reject(err);
                        console.log(err.statusText);
                    }
                });
            } else {
                alert("FormData is not supported.");
            }
        })
    }

    $(document).off(`change`, `select[name="loaiSanPham"]`).on("change", `select[name="loaiSanPham"]`, () => {
        let cateId = $(`select[name="loaiSanPham"]`).val();
        console.log(`cateId`, cateId);
        $.ajax({
            method: 'get',
            cache: false,
            url: '/api/Combobox/GetSanPhamByCategoryId',
            data: { id: cateId },
            dataType: 'json',
            success: (data) => {
                var options = `<option value="">Chọn sản phẩm</option>`
                data?.forEach((item, index) => {
                    options += `<option value="${item.id}">${item.displayName}</option>`
                });
                $(`select[name="sanPham"]`).html(options).prop('disabled', false)

            },
        });
    });

    $(document).off(`change`, `select[name="sanPham"]`).on("change", `select[name="sanPham"]`, () => {
        GetThongTinSanPham();
    });
    $(document).off(`change`, `input[name="ngayMua"]`).on("change", `input[name="ngayMua"]`, () => {
        $(`input[name="ngaySanXuat"]`).valid();
        GetThongTinSanPham();
    });
    function GetThongTinSanPham() {
        var param = {
            sanPhamId: $(`select[name="sanPham"]`).val(),
            purchaseDate: $(`input[name="ngayMua"]`).valid() ? $(`input[name="ngayMua"]`).val() : ""
        };
        console.log(`param`, param);
        $.ajax({
            method: 'get',
            cache: false,
            url: '/api/CaseRequest/GetThongTinSanPham',
            data: param,
            dataType: 'json',
            success: (res) => {
                console.log(`data`, res);
                $(`input[name="ngayHetBaoHanh"]`).val(res?.ngayHetHanBaoHanh);
                $(`select[name="tinhTrangBaoHanh"]`).val(res?.conBaoHanh).trigger("change");
                $(`select[name="hinhThucBaoHanh"]`).val(res?.loaiBaoHanh).trigger("change");
            },
            error: (err) => {
                $(`input[name="ngayHetBaoHanh"]`).val("");
                $(`select[name="tinhTrangBaoHanh"]`).val("");
                $(`select[name="hinhThucBaoHanh"]`).val("");
            }
        });
    };
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

    //Show image
    $(document).off(`click`, `.view-image"]`).on("click", `.view-image`, function () {
        let base64 = $(this).attr(`data-base64`);
        $("[name='imageView']").attr('src', base64);
        $(`#imageViewModal`).modal('show');
    });
    //Xóa image
    $(document).off(`click`, `.delete-image"]`).on("click", `.delete-image`, function () {
        let id = $(this).attr(`data-id`);
        let name = $(this).attr(`data-name`);
        if (window.confirm(`Bạn chắc chắn muốn xóa hình ảnh ${name}`)) {
            $.ajax({
                method: 'get',
                cache: false,
                url: '/api/CaseRequest/DeleteImage',
                data: { id: id },
                dataType: 'json',
                success: (data) => {
                    toastr.success(`Hình ảnh ${name} đã được xóa`, "Thông báo",);
                    $(this).closest('span').remove();
                },
            });
        }
    });


    //select change
    $(`select`).on('select2:select', function (e) {
        $('form').valid();
    });
});