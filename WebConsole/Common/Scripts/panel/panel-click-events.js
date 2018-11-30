/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function () {
    $(wcStartJobButtonId).click(function () {
        var info = $(wcJobsListId).find(":selected")
            .data("jobInfo");

        var job = new JobContent(info);
        var args = $(wcJobArgsId).val();
        startJob(job, args, function () {
            createWindow(job);
        });
        return false;
    });
});