// JavaScript Document
$(document).ready(function() {
    $("ul.tabs-news").each(function() {
        var $active,
            $content,
            $links = $(this).find("a.tbnews");

        $active = $(
            $links.filter('[href="' + location.hash + '"]')[0] || $links[0]
        );
        $active.addClass("active");
        $content = $($active.attr("href"));

        $links.not($active).each(function() {
            $($(this).attr("href")).hide();
        });

        $(this).on("click", "a.tbnews", function(e) {
            $active.removeClass("active");
            $content.hide();

            $active = $(this);
            $content = $($(this).attr("href"));

            $active.addClass("active");
            $content.show();

            e.preventDefault();
        });
    }); /*=== News close ===*/

    $("ul.tabs-character").each(function() {
        var $active,
            $content,
            $links = $(this).find("a");

        $active = $(
            $links.filter('[href="' + location.hash + '"]')[0] || $links[0]
        );
        $active.addClass("active");
        $content = $($active.attr("href"));

        $links.not($active).each(function() {
            $($(this).attr("href")).hide();
        });

        $(this).on("click", "a", function(e) {
            $active.removeClass("active");
            $content.hide();

            $active = $(this);
            $content = $($(this).attr("href"));

            $active.addClass("active");
            $content.show();

            e.preventDefault();
        });
    }); /*=== Character close ===*/
});