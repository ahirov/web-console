/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createWindow(job) {
    var container = $(wcWindowsContainerId).empty();
    var window = $.CreateDiv()
                  .addClass(wcWindowClass.GetName())
                  .data("id", job.id)
                  .hide()
                  .appendTo(container);

    createWindowHeader(job.fullName, window);

    var output = $.CreateDiv()
                  .addClass(wcWindowContentOutputClass.GetName());
    job.lines.forEach(function(value) {
        $.CreateParagraph()
         .append(value)
         .appendTo(output);
    });
    var input = $.CreateInput()
                 .addClass(wcWindowContentInputClass.GetName())
                 .keydown(windowContentKeyPressEvent);
    $.CreateDiv()
     .addClass(wcWindowContentClass.GetName())
     .append(output)
     .append(input)
     .appendTo(window)
     .click(function () {input.focus();});

    var footer = $.CreateDiv()
                  .addClass(wcWindowFooterClass.GetName())
                  .appendTo(window);
    $.CreateParagraph()
     .addClass(wcWindowStatusClass.GetName())
     .text(job.status)
     .appendTo(footer);

    window.fadeIn();
}

function createDefaultSign() {
    var defaultContainer = $.CreateDiv()
                            .addClass(wcDefaultSignClass.GetName())
                            .append("No active jobs...")
                            .hide();
    $(wcWindowsContainerId).empty().html(defaultContainer);
    defaultContainer.fadeIn();
}