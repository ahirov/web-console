/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function() {
    $(wcStartJobButtonId).click(function () {
        var selected = $(wcJobsListId).find(":selected");
        var container = $(wcAreaContainerId).empty();

        createArea("0000", selected.val(), container);
        startJobRequest({
                location: selected.data("location"),
                args: $(wcJobArgsId).val()
            },
            function() {
                var status = $.CreateParagraph()
                              .append("working...");
                $(wcAreaFooterClass).html(status);
                startReadJob();
            });
        return false;
    });
});

function areaContentKeyPressEvent(event) {
    var keyCode = event.keyCode;
    if (keyCode === 13) {
        var input = $(wcAreaContentInputClass).val();
        $.CreateParagraph()
         .append(input)
         .appendTo($(wcAreaContentOutputClass));

        $(wcAreaContentInputClass).val("");
        writeJobRequest({ input });
    }
}

function stopJobButtonEvent() {
    stopJobRequest(function () {
        var status = $.CreateParagraph()
                      .append("stopping...");
        $(wcAreaFooterClass).html(status);
        stopReadJob();
    });
    return false;
}