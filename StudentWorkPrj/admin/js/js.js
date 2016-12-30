function SetDefaultDate(id) {
    if (getQueryString("type") != null && getQueryString("type") == "Add") {
        var d = new Date();
        document.getElementById(id).value = d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate();
    }
}
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}
function GoPrePage() {
    //history.back();
    location.href = "../Order/ClientOrderManage.aspx";
}


