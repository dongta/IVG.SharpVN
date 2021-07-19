$(document).ajaxStart(function () {
    $(".loading").css('opacity',0).show();
    $(".spinner-border").show();
});
$(document).ajaxStop(function () {
    $(".loading").hide();
    $(".spinner-border").hide();
});
