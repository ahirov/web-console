/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */
function createWindowFooter(status, container) {
    var footer = $.CreateDiv()
                  .addClass(wcWindowFooterClass.GetName())
                  .appendTo(container);
    $.CreateParagraph()
     .addClass(wcWindowStatusClass.GetName())
     .appendTo(footer);
    updateWindowFooter(status, container);
}

function updateWindowFooter(status, container) {
    var line = container.find(wcWindowStatusClass)
                        .text(status.value);
    if (status.isError) {
        line.addClass(wcWindowErrorStatusClass.GetName())
            .popover({
                container: container,
                placement: "bottom",
                trigger: "hover",
                html: true
            });

        var popover = line.data("bs.popover");
        popover.config.content = status.error;
        popover.setContent();
    }
}