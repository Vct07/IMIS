var ajaxbg = $("#background,#progressBar");
ajaxbg.css("display", "block")
//ajaxbg.css("display", "none")
$(document).ajaxStart(function () {
    ajaxbg.show();
}).ajaxStop(function () {
    //ajaxbg.hide();
});