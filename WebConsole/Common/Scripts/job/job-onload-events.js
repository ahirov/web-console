/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function () {
    getAllJobsRequest(function (data) {
        var list = $(wcJobsListId);
        var jobs = JSON.parse(data);

        for (var index in jobs) {
            var job = new JobContent(jobs[index]);
            job.status = "initializing...";
            $.CreateOption()
             .data("job", job)
             .attr("title", job.name)
             .append(job.fullName)
             .appendTo(list);
        }
        list.selectpicker("refresh");
    });
});