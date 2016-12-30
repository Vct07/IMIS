var page_edit;
function ShowEdit(id, FnNmber) {
    $("#cid").val(id);
    $("#T_SealNumber").val(FnNmber);

    page_edit = $.layer({
        type: 1,   //0-4的选择,（1代表page层）
        area: ['350px', '180px'],
        shade: [0.5, '#000'],  //0不显示遮罩
        border: [0], //不显示边框
        title: [
            '修改封号',
            //自定义标题风格，如果不需要，直接title: '标题' 即可
            'border:none; background:#61BA7A; color:#fff;'
        ],
        bgcolor: '#eee', //设置层背景色
        page: {
            dom: '#ModifyArea'
        },
        shift: 'top' //从上动画弹出
    });
}

//提交
function sure() {
    var id = $("#cid").val();
    var number = $("#T_SealNumber").val();
    if (id != "" && number != "") {
        $.ajax({
            url: "../../WebService.asmx/EditShipmentDetail",
            type: "POST",
            async: false,
            //data: { id: id, SealNumber: number },
            data: '{"id":"' + id + '","SealNumber":"' + number + '"}',//
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                if (data.d.IfSuccess) {
                    alert(data.d.Message);
                    location.reload();
                } else {
                    alert(data.d.Message);
                }
            },
            error: function (data, text) {
                alert("修改失败！");
            },
            complete: function (msg) {

            }
        })
    } else {
        alert("参数错误，无法正常修改");
    }

}
function closeEdit() {
    layer.close(page_edit);
}