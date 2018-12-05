/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function () {
    $(function() {
        $("[data-toggle='tooltip']").tooltip({
            trigger: "hover"
        });
    });

    var handler = function (element, callback) {
        $(wcLogoDotClass).eq(element)
            .animate({ opacity: "1" }, 800, callback);
    };
    var animateLogo = function () {
        handler(0, function () {
            handler(1, function () {
                handler(2, function () {
                    $(wcLogoDotClass).css({ opacity: 0 });
                    animateLogo();
                });
            });
        });
    };
    animateLogo();

    $(wcModalCloseButtonClass).click(function () {
        $(wcWindowModalClass).modal("hide");
        return false;
    });
});