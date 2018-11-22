/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createArea(job) {
    var container = $(wcAreaContainerId).empty();
    var area = $.CreateDiv()
                .addClass(wcAreaClass.GetName())
                .data("id", job.id)
                .hide()
                .appendTo(container);

    createAreaHeader(job.fullName, area);

    var output = $.CreateDiv()
                 .addClass(wcAreaContentOutputClass.GetName())
                 .html(job.content);
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
     .addClass(wcAreaStatusClass.GetName())
     .text(job.status)
     .appendTo(footer);

    area.fadeIn();
}

function createDefaultArea() {
    var defaultContainer = $.CreateDiv()
                            .attr("id", wcAreaDefaultContainerId.GetName())
                            .append("No active jobs...")
                            .hide();
    $(wcAreaContainerId).empty().html(defaultContainer);
    defaultContainer.fadeIn();
}