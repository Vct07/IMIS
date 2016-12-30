var ListObj = [];
$(function () {
    var loadi = layer.load("正在努力加载中");
    $.ajax({
        type: 'POST',
        async: true,
        contentType: "application/json", //返回Json类型
        url: "../../WebService.asmx/GeOrgInfo",
        // data: '{"id":"' + getQueryString("id") + '","type":"' + type + '"}',//
        dataType: "json",
        success: function (data) {
            if (data && data.d.IfSuccess) {
                var html = "";
                
                var obj = data.d.Data;
                $.each(obj, function (i, item) {
                    
                    html += "<span class=\"lable1\" onselectstart='return   false'  ondblclick='DBClick(this)' onclick='changeOrg(this)' id=\"" + item.ID + "\" >" + item.Name + "</span>";
                });
                $("#Orghtml").empty().append(html);
                
                 
            } else {
                alert("组织数据获取失败!");
            }
        },
        error: function (e) {
            // view("异常！");    
            alert("异常错误！请联系管理员");
        },
        complete: function (e) {
            //     $("#waitInvoiceInfo").css("display", "none");
            layer.close(loadi);
        }

    });
})
function Btn_SubmitClick() {
    if (ListObj.length == 0) {
        //if(confirm("您还没有选择任何接收文件的人员，确定继续提交吗?")){
        //    Submit();
        //}
        alert("您还没有选择任何接收文件的人员");
    } else {
        Submit();
    }
   
}
function Submit() {       
    var FileName = $("#FileName").val();
    var Path = $("#FilePath").val();
    var Title = $("#Name").val();
    var Content = $("#Description").val();
    if (FileName == "" || Path == "") {
        alert("请先上传文件"); return;
    }
    if (Title == "") { alert("标题不能为空"); return; }
    var loadi = layer.load("正在提交数据");
    $.ajax({
        type: 'POST',
        async: true,
        contentType: "application/json", //返回Json类型
        url: "../../WebService.asmx/SubmitFile",
        //data: { FileName: FileName, Path: Path, PersonList: ListObj },//
        data: '{"FileName":"' + FileName + '","Path":"' + Path + '","PersonList":"' + ListObj + '","FileName":"' + FileName + '","Title":"' + Title + '","Content":"' + Content + '"}',//
        dataType: "json",
        success: function (data) {
            if (data && data.d.IfSuccess) {
                alert("提交成功");
                location.href = "/admin/File/UpFile.aspx";
            } else {
                if (data.d.Code == 1002) {
                    alert(data.d.Message);
                    location.href = "/Default.aspx";
                } else {
                    alert("提交失败");
                }
            }
        },
        error: function (e) {
            // view("异常！");    
            alert("异常错误！请联系管理员");
            
        },
        complete: function (e) {
            layer.close(loadi);
        }

    });
}
function changeOrg(e) {    
    // $(e).siblings().removeClass("lable2").addClass("lable1");
    var className = $(e).attr('class');
    $(e).removeClass("lable1").addClass("lable2");
    if (className == "lable2") {
        GetPersion($(e)[0].id, 3);
    }
    else {
        GetPersion($(e)[0].id, 1);
    }
}
function DBClick(e) {
    var className = $(e).attr('class');
    if (className == "lable2") {
        $(e).removeClass("lable2").addClass("lable1");
    }
   
    //$(e).siblings().removeClass("lable2").addClass("lable1");
    GetPersion($(e)[0].id,0)
}
function GetPersion(id,flg) {
    $("#Persionhtml").empty();
   // var loadi = layer.load("正在努力获取账户信息");
    $.ajax({
        type: 'POST',
        async: true,
        contentType: "application/json", //返回Json类型
        url: "../../WebService.asmx/GePersionInfo",
        data: '{"id":"' + id + '"}',//
        dataType: "json",
        success: function (data) {
            if (data && data.d.IfSuccess) {                
                var html2 = "";
                var obj = data.d.Data;
                $.each(obj, function (i, item) {
                    if (flg == 1) {
                        AddPersion(item.ID);
                        html2 += "<input type=\"checkbox\" onchange='checkChange(this)' checked=\"checked\" style=\"margin-left:10px;\" value=\"" + item.ID + "\" />" + item.Name;
                    }
                    if (flg == 0) {
                        ListObj.remove(item.ID);
                        html2 += "<input type=\"checkbox\" onchange='checkChange(this)' style=\"margin-left:10px;\" value=\"" + item.ID + "\" />" + item.Name;
                    }
                    if (flg == 3) {
                        if(ListObj.indexOf(item.ID)==-1){
                            html2 += "<input type=\"checkbox\" onchange='checkChange(this)' style=\"margin-left:10px;\" value=\"" + item.ID + "\" />" + item.Name;
                        } else {
                            html2 += "<input type=\"checkbox\" onchange='checkChange(this)' checked=\"checked\" style=\"margin-left:10px;\" value=\"" + item.ID + "\" />" + item.Name;
                        }
                    }
                    
                });                
                $("#Persionhtml").empty().append(html2);

            } else {
                //alert("账户数据获取失败!");
            }
        },
        error: function (e) {
            // view("异常！");    
            alert("异常错误！请联系管理员");
        },
        complete: function (e) {
            
            //layer.close(loadi);
        }

    });
}
function checkChange(e) {
    if ($(e).attr("checked")) {
        if (ListObj.indexOf($(e).val()) == -1) {
            ListObj.push($(e).val());
        }
    } else {
        if (ListObj.indexOf($(e).val()) != -1) {
            ListObj.remove($(e).val());
        }
    }
}
function AddPersion(obj) {
    if (ListObj.indexOf(obj)==-1) {
        ListObj.push(obj);
    }
 
}
 

 
Array.prototype.indexOf = function (val) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == val) return i;
    }
    return -1;
};
Array.prototype.remove = function (val) {
    var index = this.indexOf(val);
    if (index > -1) {
        this.splice(index, 1);
    }
};