$(function () {
    $(document).ready(function () {
        $("select").select2({
            theme: "classic",
            width: 'resolve'
        });
    });
    
    $(document).off("click", "#btnUpdate").on("click", "#btnUpdate", () => {
        $("#techUpdate").show();
    });
    $(document).off("click", "#btnCancelJob").on("click", "#btnCancelJob", () => {
        $("#canceljobContainer").show();
    });

    $(document).off("click", `a[name="btn-tech-save"]`).on("click", `a[name="btn-tech-save"]`, () => {
        var serviceCenterId = $("#assignedServiceCenterId").val();
        $.ajax({
            method: 'post',
            cache: false,
            url: '/api/Case/AssignJob',
            data: { id: caseId, serviceCenterId: serviceCenterId },
            dataType: 'json',
            success: (data) => {
                toastr.success("Phiếu yêu cầu đã được phân công.", "Phân công thành công",);
                $("#techUpdate").hide();
                $(".tenTrungTamDuocAssign").html($("#assignedServiceCenterId option:selected").text())
                $(".trangThaiSuaChuaText").text("Đã chuyển thành job");
                setTimeout(function () {
                    location.reload();
                }, 3000);
            },
        });
    });
    $(document).off("click", `a[name="btn-tech-cancel"]`).on("click", `a[name="btn-tech-cancel"]`, () => {
        $("#techUpdate").hide();
    });

    $(document).off("click", `a[name="btn-tech-savecancel"]`).on("click", `a[name="btn-tech-savecancel"]`, () => {
        if (window.confirm("do you sure cancel this job?")) {
            var cancelReasonId = $("#cancelReasonId").val();
            $.ajax({
                method: 'post',
                cache: false,
                url: '/api/Case/CancelJob',
                data: { id: caseId, cancelReasonId: cancelReasonId },
                dataType: 'json',
                success: (data) => {
                    toastr.success("Đã được hủy.", "Hủy thành công",);
                    $("#canceljobContainer").hide();
                    setTimeout(function () {
                        location.reload();
                    }, 3000);
                },
            });
        }
    });
    $(document).off("click", `a[name="btn-tech-back-cancel"]`).on("click", `a[name="btn-tech-back-cancel"]`, () => {
        $("#canceljobContainer").hide();
    });
    //Show image
    $(document).off(`click`, `.view-image"]`).on("click", `.view-image`, function () {
        let base64 = $(this).attr(`data-base64`);
        $("[name='imageView']").attr('src', base64);
        $(`#imageViewModal`).modal('show');
    });
});