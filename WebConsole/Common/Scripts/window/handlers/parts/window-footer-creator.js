/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createWindowFooter(status, container) {
    var footer = $.CreateDiv()
                  .addClass(wcWindowFooterClass.GetName())
                  .appendTo(container);
    $.CreateParagraph()
     .addClass(wcWindowStatusClass.GetName())
     .text(status)
     .appendTo(footer);
}