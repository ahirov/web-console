﻿/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function getWindowContainer(id) {
    return $(wcWindowContainerClass).filter(function () {
        return $(this).data("id") === id;
    }).first();
}

function createDefaultSign(id) {
    var defaultSign = $.CreateDiv()
                       .addClass("d-flex")
                       .addClass("align-items-end")
                       .addClass("justify-content-end")
                       .addClass(wcDefaultSignClass.GetName())
                       .append("No active job...")
                       .hide();
    var container = id
        ? getWindowContainer(id)
        : $(wcWindowContainerClass);
    container.empty()
             .data("id", null)
             .append(defaultSign.clone());
    container.children().fadeIn();
}