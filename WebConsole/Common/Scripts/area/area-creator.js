/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createNewArea(id, title, container) {
    var area = $.CreateDiv()
                .addClass(wcAreaClass.GetName())
                .hide()
                .appendTo(container);

    createAreaHeader(id, title, area);

    var content = $.CreateDiv()
                   .addClass(wcAreaContentClass.GetName())
                   .appendTo(area);
    $.CreateParagraph()
     .append("Output data 01011110101")
     .appendTo(content);
    $.CreateSpan()
     .addClass("wc-blinking-cursor")
     .append("|")
     .appendTo(content);

    var footer = $.CreateDiv()
                  .addClass(wcAreaFooterClass.GetName())
                  .appendTo(area);
    $.CreateParagraph()
     .append("initializing...")
     .appendTo(footer);

    area.fadeIn();
}