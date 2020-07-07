$(function () {
    if(jQuery("#img").length > 0) {
        jQuery("#img").fadegallery({
            control_event: "mouseover",
            auto_play: true,
            control: jQuery("ul#imgControl"),
            delay: 3
        });
    }
});






