/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createWindowContent(id, lines, container) {
    var output = $.CreateDiv()
                  .addClass(wcWindowContentOutputClass.GetName());
    lines.forEach(function (value) {
        $.CreateParagraph()
         .append(value)
         .appendTo(output);
    });
    var input = $.CreateInput()
                 .addClass(wcWindowContentInputClass.GetName())
                 .keydown(windowContentKeyPressEvent)
                 .data("id", id);
    $.CreateDiv()
     .addClass(wcWindowContentClass.GetName())
     .append(output)
     .append(input)
     .appendTo(container)
     .click(function () { input.focus(); });
}