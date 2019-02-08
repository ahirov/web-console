/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function () {
    $(wcStartJobButtonId).click(startJobButtonEvent);

    $(wcJobDescriptionsButtonId).click(function() {
        getJobDescriptionsReguest(function(data) {
            processJobDescriptionsWindow(JSON.parse(data));
        });
        return false;
    });

    $(wcStopJobsButtonId).click(function () {
        stopJobs();
        $(wcTabsContainerId).empty();
        return false;
    });
});

function startJobButtonEvent() {
    disableStartJobButton();
    var info = $(wcJobsListId).find(":selected")
                              .data("jobInfo");
    var job = new JobContent();
    job.status = new JobStatus();
    job.location = info.location;
    job.name     = info.name;
    job.fullName = info.namespace
           + "." + info.name;
    saveJob(job);

    var args = $(wcJobArgsId).val();
    startJob(job.location, args);
    return false;
}

function startJobDisabledButtonEvent() {
    return false;
}