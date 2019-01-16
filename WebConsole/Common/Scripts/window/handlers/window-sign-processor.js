/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createDefaultSign(id) {
    var defaultSign = $.CreateDiv()
                       .addClass("d-flex")
                       .addClass("align-items-end")
                       .addClass("justify-content-end")
                       .addClass(wcDefaultContentClass.GetName())
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