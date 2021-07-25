
$(function () {
    var tbl;
    $(document).ready(function () {
        tbl = $('#ListCaseRequest').DataTable({
            processing: false,
            serverSide: true,
            paging: true,
            sDom: 'lrtip',
            bFilter: false,
            //bInfo: false,
            //dom: '<"top"i>rt<"bottom"flp><"clear">',
            dom: 'Bfrtip',
            ajax: {
                url: `/api/CaseRequest/GetRequest`,
                type: "POST",
                dataType: 'json',
                contentType: "application/json;charset=utf-8",
                data: function (d) {
                    var orderBy = `${d.columns[d.order[0].column].data} ${d.order[0].dir}`;
                    d = $.extend({}, d, {
                        "filterText": $(`[name="textsearch"]`).val(),
                        orderBy: orderBy
                    });
                    var formArray = $("#formFilter").serializeArray();
                    var formData = {};
                    $.map(formArray, function (n, i) {
                        formData[n['name']] = n['value'];
                    });
                    d = $.extend({}, d, formData);
                    delete d.columns;
                    delete d.order;
                    delete d.search;
                    console.log(JSON.stringify(d), d);
                    return JSON.stringify(d);
                },
                dataSrc: 'data'
            },
            columns: [
                {
                    data: "maPhieu",
                    width: '120px',
                },
                {
                    data: "maThamChieu",
                    width: '120px'
                },
                {
                    data: "soSerial",
                    width: '120px'
                },
                {
                    data: "tenKhachHang",
                    className: 'text-truncate col-1',
                    width: '120px'
                }, {
                    data: "diaChi",
                    width: '120px'
                }, {
                    data: "soDienThoai",
                    width: '120px'
                },
                {
                    data: "soDienThoaiKhac",
                    width: '120px'
                },
                {
                    data: "maSanPham",
                    width: '120px'
                },
                {
                    data: "maLoi",
                    width: '120px'
                },
                {
                    data: "tenTrungTam",
                    width: '120px'
                },
                {
                    data: "tenKTV",
                    width: '120px'
                },
                {
                    data: "nguoiTiepNhan",
                    width: '120px'
                },
                {
                    data: "nguoiTiepNhan",
                    width: '120px'
                },
                {
                    data: "trangThaiSuaChua",
                    width: '120px'
                },
                {
                    data: "dienGiaiLoi",
                    width: '120px'
                },
            ],
            //drawCallback: function (data) {
            //    console.log(`drawCallback`,data);
            //},
            rowCallback: (row, data, displayNum, displayIndex, dataIndex) => {
                //console.log(`row`, data);
            }
            //"infoCallback": function (settings, start, end, max, total, pre) {
            //    console.log();
            //    return start + " to " + end;
            //}
        });
    });

    $('#ListCaseRequest tbody').on('dblclick', 'tr', function () {
        var data = tbl.row(this).data();
        var id = data.requestId;
        window.location = `/dealer/servicedetail?id=${id}`;
    });

    $(`[name="textsearch"]`).on('keyup', function (e) {
        if (e.key === 'Enter' || e.keyCode === 13) {
            $('#collapseFilter').find("input[type=text], input[type=date], textarea, select").val("");
            tbl.ajax.reload();
        }
    });
    $("#quickSearch").on('click', () => {
        $('#collapseFilter').find("input[type=text], input[type=date], textarea, select").val("");
        tbl.ajax.reload();
    });
    $("#btnCollapseFilter").on('click', () => {
        $('[name="textsearch"]').val("");
    });

    $("#btnClearFilter").on('click', () => {
        $('#collapseFilter').find("input[type=text], input[type=date], textarea, select").val("");
        tbl.ajax.reload();
    });
    $("#btnFilter").on('click', () => {
        tbl.ajax.reload();
    });

});