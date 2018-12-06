/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function () {
    getJobInfosRequest(function (data) {
        var list = $(wcJobsListId);
        var infos = JSON.parse(data);

        for (var index in infos) {
            var info = infos[index];
            $.CreateOption()
             .data("jobInfo", info)
             .attr("title", info.name)
             .append(info.fullName)
             .appendTo(list);
        }
        list.selectpicker("refresh");
        initJobStreamHub();
    });

    addEventListener("beforeunload", function () {
        var ids = Object.values(loadAllJobs())
                        .filter(function(job) {
                            return job.id;
                        })
                        .map(function (job) {
                            return job.id;
                        });
        var data = { data: JSON.stringify(ids) };
        stopOwnJobsRequest(data, function () {
            clearStorage();
        });
    });
});