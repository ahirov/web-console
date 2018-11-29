/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function() {
    $(wcStartJobButtonId).click(function () {
        var info = $(wcJobsListId).find(":selected")
                                  .data("jobInfo");

        var job = new JobContent(info);
        var args = $(wcJobArgsId).val();
        startReadJob(job, args, function() {
            createArea(job);
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

        var id = $(wcAreaClass).data("id");
        var stream = $.connection.streamHub;
        stream.server.write(id, input);
    }
}