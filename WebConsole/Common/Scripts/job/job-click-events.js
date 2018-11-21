/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function() {
    $(wcStartJobButtonId).click(function () {
        var selected = $(wcJobsListId).find(":selected");
        var container = $(wcAreaContainerId).empty();

        createNewArea("0000", selected.val(), container);
        startJobRequest({
                location: selected.data("location"),
                args: $(wcJobArgsId).val()
            },
            function() {
                //$(wcOutputContainerId).append("<p>Console started!!!</p>");
                //startReadJob();
            });
        return false;
    });

    $(wcStopJobButtonId).click(function () {
        stopJobRequest(function() {
            //$(wcOutputContainerId).append("<p>Console stopped!!!</p>");
            //stopReadJob();
        });
        return false;
    });

    $(wcJobInputId).keypress(function (e) {
        if (e.keyCode === 13) {
            writeJobRequest({
                input: $(wcJobInputId).val()
            });
        }
    });
});