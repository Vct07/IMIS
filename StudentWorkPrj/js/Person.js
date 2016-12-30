$(function () {
    InitSkills();
});
function InitSkills() {
    if (getQueryString("id") != "" || getQueryString("Type") == "Modify") {
        //$("#tr_skill").css("display", "block");
        $.ajax({
            type: 'POST',
            async: true,
            contentType: "application/json", 
            url: "../../WebService.asmx/GeSkillInfo",
            data: '{"pid":"' + getQueryString("id") + '"}',//
            dataType: "json",
            success: function (data) {
                if (data && data.d.IfSuccess) {
                    var html = "";

                    var obj = data.d.Data;
                    $.each(obj, function (i, item) {
                        if (item.Type == "check") {
                            html += "<input type=\"checkbox\" style=\"margin-left:5px\" checked=\"checked\"  onchange='changeskill(this)' id=\"" + item.ID + "\" />" + item.Name;
                        } else {
                            html += "<input type=\"checkbox\" style=\"margin-left:5px\"  onchange='changeskill(this)' id=\"" + item.ID + "\" />" + item.Name;
                        }
                    });
                    $("#skills").empty().append(html);


                } else {
                    alert("init skill data error!");
                }
            },
            error: function (e) {
                // view("异常错误！");    
                alert("exception error!");
            },
            complete: function (e) {
                
            }

        });
    } else {
        $("#tr_skill").css("display", "none");
    }
}

function changeskill(e) {
    if (getQueryString("id") != "") {
        var t = $("#" + $(e)[0].id).attr("checked")?"1":"0";        
        $.ajax({
            type: 'POST',
            async: true,
            contentType: "application/json", //返回Json类型
            url: "../../WebService.asmx/SetSkill",            
            data: '{"skill_FK":"' + $(e)[0].id + '","Person_FK":"' + getQueryString("id") + '","T":"' + t + '"}',//
            dataType: "json",
            success: function (data) {
                if (data && data.d.IfSuccess) {
                  
                } else { 
                   alert("save skill fail"); 
                }
            },
            error: function (e) {
                // view("异常！");    
                alert("exception error");

            },
            complete: function (e) {
                
            }

        });
    }
}
 

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return "";
}