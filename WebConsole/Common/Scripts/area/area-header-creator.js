/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createAreaHeader(id, title, container) {
    var header = $.CreateDiv()
                  .addClass("d-flex")
                  .addClass("align-items-center")
                  .addClass(wcAreaHeaderClass.GetName())
                  .appendTo(container);

    $.CreateSpan()
     .addClass("mr-auto")
     .append(title)
     .appendTo(header);

    $.CreateLink()
     .append($.CreateIcon("far", "fa-window-minimize"))
     .appendTo(header);
    $.CreateLink()
     .append($.CreateIcon("far", "fa-window-maximize"))
     .appendTo(header);
    $.CreateLink()
     .click(stopJobButtonEvent)
     .append($.CreateIcon("far", "fa-window-close"))
     .appendTo(header);
}