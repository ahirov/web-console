/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createArea(id, title, container) {
    var area = $.CreateDiv()
                .addClass(wcAreaClass.GetName())
                .hide()
                .appendTo(container);

    createAreaHeader(id, title, area);

    var output = $.CreateDiv()
                  .addClass(wcAreaContentOutputClass.GetName());
    var input = $.CreateInput()
                 .addClass(wcAreaContentInputClass.GetName())
                 .keydown(areaContentKeyPressEvent);
    $.CreateDiv()
     .addClass(wcAreaContentClass.GetName())
     .append(output)
     .append(input)
     .appendTo(area)
     .click(function () {input.focus();});

    var footer = $.CreateDiv()
                  .addClass(wcAreaFooterClass.GetName())
                  .appendTo(area);
    $.CreateParagraph()
     .text("initializing...")
     .appendTo(footer);

    area.fadeIn();
}