
$(function () {
    var tbl;
    $(document).ready(function () {
        tbl = $('#tblUsers').DataTable({
            processing: false,
            serverSide: true,
            paging: true,
            sDom: 'lrtip',
            bFilter: false,
            //bInfo: false,
            //dom: '<"top"i>rt<"bottom"flp><"clear">',
            dom: 'Bfrtip',
            ajax: {
                url: `/api/Admin/GetAll`,
                type: "POST",
                dataType: 'json',
                contentType: "application/json;charset=utf-8",
                data: function (d) {
                    var orderBy = `${d.columns[d.order[0].column].data} ${d.order[0].dir}`;
                    d = $.extend({}, d, {
                        "filterText": $(`[name="textsearch"]`).val(),
                        orderBy: orderBy
                    });
                    delete d.columns;
                    delete d.order;
                    delete d.search;
                    return JSON.stringify(d);
                },
                dataSrc: 'data'
            },
            columns: [
                {
                    data: "userName",
                    width: '120px',
                },
                {
                    data: "displayName",
                    width: '120px'
                },
                {
                    data: "address",
                    width: '120px'
                },
                {
                    data: "email",
                    className: 'text-truncate col-1',
                    width: '120px'
                }, {
                    data: "phone",
                    width: '120px'
                }, {
                    data: "mobilePhone",
                    width: '120px'
                },
                {
                    data: "description",
                    width: '120px'
                },
                {
                    data: "ascName",
                    width: '120px'
                },
                {
                    data: "activeName",
                    width: '120px'
                }
            ],
            //drawCallback: function (data) {
            //    console.log(`drawCallback`,data);
            //},
            rowCallback: (row, data, displayNum, displayIndex, dataIndex) => {
                console.log(`row`, data);
            }
            //"infoCallback": function (settings, start, end, max, total, pre) {
            //    console.log();
            //    return start + " to " + end;
            //}
        });
    });

    $('#tblUsers tbody').on('dblclick', 'tr', function () {
        var data = tbl.row(this).data();
        var id = data.id;
        window.location = `/admin/adduser?id=${id}`;
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
});