$(function () {
    var tbl;
    $(document).ready(function () {
        tbl = $('#ListCase').DataTable({
            processing: false,
            serverSide: true,
            paging: true,
            sDom: 'lrtip',
            bFilter: false,
            //bInfo: false,
            //dom: '<"top"i>rt<"bottom"flp><"clear">',
            dom: 'Bfrtip',
            ajax: {
                url: `/api/Case/GetAll`,
                type: "POST",
                dataType: 'json',
                contentType: "application/json;charset=utf-8",
                data: function (d) {
                    var orderBy = `${d.columns[d.order[0].column].data} ${d.order[0].dir}`;
                    d = $.extend({}, d, {
                        "filterText": $(`[name="textsearch"]`).val(),
                        orderBy: orderBy
                    });
                    var formArray = $(`form[name='frmFilter']`).serializeArray();
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
                    data: "caseCode",
                    width: '120px',
                },
                {
                    data: "requestCode",
                    width: '120px'
                },
                {
                    data: "referenceCode",
                    width: '120px'
                },
                {
                    data: "customerName",
                    className: 'text-truncate col-1',
                    width: '120px'
                }, {
                    data: "customerAddress",
                    width: '120px'
                }, {
                    data: "customerPhone",
                    width: '120px'
                },
                {
                    data: "customerOtherPhone",
                    width: '120px'
                },
                {
                    data: "maSanPham",
                    width: '120px'
                },
                {
                    data: "defectCode",
                    width: '120px'
                },
                {
                    data: "ascName",
                    width: '120px'
                },
                {
                    data: "technicianName",
                    width: '120px'
                },
                {
                    data: "receivedBy",
                    width: '120px'
                },
                {
                    data: "receivedDate",
                    width: '120px'
                },
                {
                    data: "repairStatusName",
                    defaultContent:'Chưa xử lý',
                    width: '120px'
                },
                {
                    data: "description",
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

    $(document).off("click", "#exportExcel").on("click", "#exportExcel", (a) => {
        var d = {};
        d = $.extend({}, d, {
            "filterText": $(`[name="textsearch"]`).val()
        });
        var formArray = $(`form[name='frmFilter']`).serializeArray();
        var formData = {};
        $.map(formArray, function (n, i) {
            formData[n['name']] = n['value'];
        });
        d = $.extend({}, d, formData);
        d = JSON.stringify(d);

        $.ajax({
            method: 'post',
            cache: false,
            url: '/api/Case/ExportExcel',
            data: d,
            dataType: 'json',
            processData: false,
            success: (res) => {
                //let blob = new Blob([res], { type: "application/octetstream" });
                //var date = $("#currentDate").val();
                //let a = document.createElement('a');
                //a.href = window.URL.createObjectURL(blob);
                //a.download = `ServiceLog-${date}.xlsx`;
                //document.body.appendChild(a);
                //a.click();
                //document.body.removeChild(a);
                //toastr.success("Thông báo.", "Tải file thành công",);
            },
        }).then(resp => resp.blob())
            .then(blob => {
                const url = window.URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.style.display = 'none';
                a.href = url;
                // the filename you want
                a.download = 'todo-1.xlsx';
                document.body.appendChild(a);
                a.click();
                window.URL.revokeObjectURL(url);
                alert('your file has downloaded!'); // or you know, something with better UX...
            })
            .catch(() => alert('oh no!'));;
    });

    $('#ListCase tbody').on('dblclick', 'tr', function () {
        var data = tbl.row(this).data();
        var id = data.caseID;
        window.location = `/Staff/UpdateJob?id=${id}`;
    });

    $(document).off("click", "#filter").on("click", "#filter", (a) => {
        $("form[name='frmFilter']").toggle("fade");
        $("#frmFilterAction").toggle('slow');
    });
    $(document).off("click", "#btnClearSearch").on("click", "#btnClearSearch", (a) => {
        
        $(`form[name='frmFilter']`).find("input[type=text], input[type=date], textarea, select").val("");
        tbl.ajax.reload();
    });
    $(document).off("click", "#btnSearch").on("click", "#btnSearch", (a) => {
        tbl.ajax.reload();
    });
});