$(document).ready(function() {
    $(".various").fancybox({
        maxWidth: 375,
        maxHeight: 470,
        fitToView: false,
        width: "375",
        height: "470",
        autoSize: false,
        closeClick: false,
        openEffect: "none",
        closeEffect: "none",
        padding: 0,
    });
});
$(window).load(function() {
    $("#slider").nivoSlider();

    $("#owl-monphai").slick({
        dots: false,
        infinite: false,
        speed: 300,
        slidesToShow: 6,
        slidesToScroll: 6,
    });
});
var popup_status = 0;
$(document).ready(function() {
    if (popup_status == 1) {
        $("#login-box").css("display", "none");
        $("#mask").css("display", "none");
    } else {
        setTimeout(function() {
            if ($("#close").attr("rel") == 1) {
                FadePopup("a.login-window");
            }
        }, 3000);
    }
});