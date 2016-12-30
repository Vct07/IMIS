$(function () {
    var loadi = layer.load("正在努力加载中");
    $.ajax({
        type: 'POST',
        async: true,
        contentType: "application/json", //返回Json类型
        url: "../../WebService.asmx/GetNewUsdInfo",
        // data: '{"id":"' + getQueryString("id") + '","type":"' + type + '"}',//
        dataType: "json",
        success: function (data) {
            if (data && data.d.IfSuccess) {
                $("#usdinfo").text("汇率:【" + data.d.Message + "】   时间:【" + (data.d.Datetime).toString() + "】");
                //alert("success")
            } else {
                $("#usdinfo").text("");
                alert(data.d.Message);
            }
        },
        error: function (e) {
            // view("异常！");    
            alert("异常错误！请稍后重试");
        },
        complete: function (e) {
            //     $("#waitInvoiceInfo").css("display", "none");
            layer.close(loadi);
        }

    });
})