/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function() {
    $(wcStartJobButtonId).click(function () {
        var job = $(wcJobsListId).find(":selected")
                                 .data("job");
        createArea(job);
        startJobRequest({
                id: job.id,
                location: job.location,
                args: $(wcJobArgsId).val()
            },
            function() {
                $(wcAreaStatusClass).text("working...");
                saveJob(job);
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