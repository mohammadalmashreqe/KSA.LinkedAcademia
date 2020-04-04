document.addEventListener('DOMContentLoaded', function () {
    $('.card-header').on('click', '[data-fa-i2svg]', function () {
        $("#sidebar-content")
            .removeClass("w-100")
            .width($("#sidebar").width());
        $("#sidebar").css({ "flex": "none" });
        $("#sidebar").animate({
            width: "toggle"
        }, 600, function () {
            $("#sidebar").css({ "flex": '', "width": '' });
            $("#sidebar-content")
                .css("width", "")
                .addClass("w-100");
        });
    });

    $("#search").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#friend-list li .username").filter(function () {
            $(this).parent().toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });

});