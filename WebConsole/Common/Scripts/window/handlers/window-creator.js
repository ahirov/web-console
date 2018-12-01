/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createWindow(job, rawContainer) {
    var id = job.id;
    var container = rawContainer.empty()
                                .data("id", id);
    var window = $.CreateDiv()
                  .addClass(wcWindowClass.GetName())
                  .hide()
                  .appendTo(container);
    createWindowHeader(id, job.fullName, window);

    var output = $.CreateDiv()
                  .addClass(wcWindowContentOutputClass.GetName());
    job.lines.forEach(function(value) {
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

function createDefaultSign(id) {
    var defaultSign = $.CreateDiv()
                       .addClass("d-flex")
                       .addClass("align-items-center")
                       .addClass("justify-content-end")
                       .addClass(wcDefaultSignClass.GetName())
                       .append("No active jobs...")
                       .hide();
    var container = id
        ? getWindowContainer(id)
        : $(wcWindowContainerClass);
    container.empty()
             .data("id", null)
             .append(defaultSign.clone());
    container.children().fadeIn();
}