function DownContract(order_fk) {
    if (order_fk!="") {
        $.ajax({
            type: 'POST',
            contentType: "application/json", //返回Json类型
            url: "../../WebService.asmx/DownFile",
            data: '{"id":"' + order_fk + '"}',//
            dataType: "json",
            success: function (data) {
                if (data && data.d.IfSuccess) {
                    if (data.d.FilePath == "") {
                        alert("合同文件还未创建，暂时不能下载");
                    } else {//执行下载
                       
                        var aLink = document.createElement('a');

                        aLink.download = order_fk;
                        aLink.href = "/" + data.d.FilePath;;
                        if (getOs() == "MSIE" || getOs() == "Firefox") {//IE的处理 
                            aLink.style.display = "none";
                            document.body.appendChild(aLink);
                            aLink.click();
                        } else {//非IE
                            var evt = document.createEvent("HTMLEvents");
                            evt.initEvent("click", false, false);
                            aLink.dispatchEvent(evt);
                        }

                    }
                } else {
                    alert(data.d.Message);
                }
            },
            error: function (e) {
                // view("异常！");    
                alert("异常错误！请稍后重试");
            }

        });
    } else {
        alert("请不要恶意操作系统，参数有误！")
    }
}

function CreateContract() {
    if (getQueryString("id") != "") {
        $("#waitInfo").css("display","block");
        $.ajax({
            type: 'POST',
            async: true,
            contentType: "application/json", //返回Json类型
            url: "../../WebService.asmx/CreatContract",
            data: '{"id":"' + getQueryString("id") + '"}',//
            dataType: "json",
            success: function (data) {
                if (data && data.d.IfSuccess) {
                    alert(data.d.Message);
                } else {
                    alert(data.d.Message);
                }
            },
            error: function (e) {
                // view("异常！");    
                alert("异常错误！请稍后重试");
            },
            complete: function (e) {
                $("#waitInfo").css("display", "none");
            }

        });
    } else {
        alert("请不要恶意操作系统，参数有误！")
    }
}

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}
function getOs() {
    var OsObject = "";
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        return "MSIE";
    }
    if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {
        return "Firefox";
    }
    if (isSafari = navigator.userAgent.indexOf("Safari") > 0) {
        return "Safari";
    }
    if (isCamino = navigator.userAgent.indexOf("Camino") > 0) {
        return "Camino";
    }
    if (isMozilla = navigator.userAgent.indexOf("Gecko/") > 0) {
        return "Gecko";
    }

}

function CreateInvoice() {
    if (getQueryString("id") != "") {
       // $("#waitInvoiceInfo").css("display", "block");
        $.ajax({
            type: 'POST',
            async: true,
            contentType: "application/json", //返回Json类型
            url: "../../WebService.asmx/CreatInvoice",
            data: '{"id":"' + getQueryString("id") + '"}',//
            dataType: "json",
            success: function (data) {
                if (data && data.d.IfSuccess) {
                    var aLink = document.createElement('a');
                    aLink.download = getQueryString("id");
                    aLink.href = "/" + data.d.Message;;
                    if (getOs() == "MSIE" || getOs() == "Firefox") {//IE的处理 
                        aLink.style.display = "none";
                        document.body.appendChild(aLink);
                        aLink.click();
                    } else {//非IE
                        var evt = document.createEvent("HTMLEvents");
                        evt.initEvent("click", false, false);
                        aLink.dispatchEvent(evt);
                    }                     
                } else {
                    alert(data.d.Message);
                }
            },
            error: function (e) {
                // view("异常！");    
                alert("异常错误！请稍后重试");
            },
            complete: function (e) {
           //     $("#waitInvoiceInfo").css("display", "none");
            }

        });
    } else {
        alert("请不要恶意操作系统，参数有误！")
    }
}

function CreatePackingList() {
    if (getQueryString("id") != "") {
     //   $("#waitPackingListInfo").css("display", "block");
        $.ajax({
            type: 'POST',
            async: true,
            contentType: "application/json", //返回Json类型
            url: "../../WebService.asmx/CreatPackingList",
            data: '{"id":"' + getQueryString("id") + '"}',//
            dataType: "json",
            success: function (data) {
                if (data && data.d.IfSuccess) {
                    var aLink = document.createElement('a');
                    aLink.download = getQueryString("id");
                    aLink.href = "/" + data.d.Message;;
                    if (getOs() == "MSIE" || getOs() == "Firefox") {//IE的处理 
                        aLink.style.display = "none";
                        document.body.appendChild(aLink);
                        aLink.click();
                    } else {//非IE
                        var evt = document.createEvent("HTMLEvents");
                        evt.initEvent("click", false, false);
                        aLink.dispatchEvent(evt);
                    }                     
                } else {
                    alert(data.d.Message);
                }
            },
            error: function (e) {
                // view("异常！");    
                alert("异常错误！请稍后重试");
            },
            complete: function (e) {
            //    $("#waitPackingListInfo").css("display", "none");
            }

        });
    } else {
        alert("请不要恶意操作系统，参数有误！")
    }
}

function CreateOrderContract(type) {
    var loadi = layer.load(0);
    if (getQueryString("id") != "") {
         
        // $("#waitInvoiceInfo").css("display", "block");
        $.ajax({
            type: 'POST',
            async: true,
            contentType: "application/json", //返回Json类型
            url: "../../WebService.asmx/CreatOrderContract",
            data: '{"id":"' + getQueryString("id") + '","type":"' + type + '"}',//
            dataType: "json",
            success: function (data) {
                if (data && data.d.IfSuccess) {
                    var aLink = document.createElement('a');
                    aLink.download = getQueryString("id");
                    aLink.href = "/" + data.d.Message;;
                    if (getOs() == "MSIE" || getOs() == "Firefox") {//IE的处理 
                        aLink.style.display = "none";
                        document.body.appendChild(aLink);
                        aLink.click();
                    } else {//非IE
                        var evt = document.createEvent("HTMLEvents");
                        evt.initEvent("click", false, false);
                        aLink.dispatchEvent(evt);
                    }
                } else {
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
    } else {
        alert("请不要恶意操作系统，参数有误！")
    }
}

