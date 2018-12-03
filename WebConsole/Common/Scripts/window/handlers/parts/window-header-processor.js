/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createWindowHeader(id, title, container) {
    var header = $.CreateDiv()
                  .addClass("d-flex")
                  .addClass("align-items-center")
                  .addClass(wcWindowHeaderClass.GetName())
                  .appendTo(container);

    $.CreateSpan()
     .addClass("mr-auto")
     .append(title)
     .appendTo(header);

    $.CreateLink()
     .data("id", id)
     .addClass(wcWindowMinimizeButtonClass.GetName())
     .append($.CreateIcon("far", "fa-window-minimize"))
     .appendTo(header)
     .click(windowMinimizeButtonEvent);
    $.CreateLink()
     .append($.CreateIcon("far", "fa-window-maximize"))
     .appendTo(header)
     .click(windowMaximizeButtonEvent);
    $.CreateLink()
     .data("id", id)
     .append($.CreateIcon("far", "fa-window-close"))
     .appendTo(header)
     .click(windowCloseButtonEvent);
}