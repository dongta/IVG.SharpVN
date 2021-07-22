
$(function () {
    $(document).ready(function () {
        $('#ListCaseRequest').DataTable({
            processing: false,
            serverSide: true,
            paging: true,
            ajax: {
                url: `/api/CaseRequest/GetRequest`,
                type: "POST",
                dataType:'json',
                contentType: "application/json;charset=utf-8",
                //ajax: getData(),
                dataSrc:'data'
            },
            columns: [
                {
                    data: "maPhieu",
                    defaultContent:''
                },
                {
                    data: "maThamChieu",
                    defaultContent: ''
                },
                {
                    data: "tenKhachHang",
                    defaultContent: ''
                },
            ]
        });
    });

    function getData() {
        $.ajax({
            method: 'post',
            cache: false,
            url: apiBaseUrl + '/CaseRequest/GetRequest',
            data: { pageIndex: 1, pageSize: 155 },
            dataType: 'json',
            contentType: "application/json;charset=utf-8",
            success: (res) => {
                console.log(`result`, res);
            },
            error: (err) => {
                console.log(`err`, err);
            },
        });
    };
});