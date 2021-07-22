
$(function () {
    var tbl;
    $(document).ready(function () {
      tbl=  $('#ListCaseRequest').DataTable({
            processing: false,
            serverSide: true,
            paging: true,
            sDom: 'lrtip',
            bFilter: false,
            //bInfo: false,
            dom: '<"top"i>rt<"bottom"flp><"clear">',
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
                    console.log(`inut`, d);
                    return JSON.stringify(d);
                },
                dataSrc: 'data'
            },
            columns: [
                {
                    data: "requestId",
                },
                {
                    data: "maThamChieu",
                },
                {
                    data: "tenKhachHang",
                },
            ],
            //drawCallback: function (data) {
            //    console.log(`drawCallback`,data);
            //},
            rowCallback:(row, data, displayNum, displayIndex, dataIndex)=> {
                console.log(`row`, data);
            }
            //"infoCallback": function (settings, start, end, max, total, pre) {
            //    console.log();
            //    return start + " to " + end;
            //}
        });
    });

    $(`[name="textsearch"]`).on('change', () => {
        tbl.ajax.reload();
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