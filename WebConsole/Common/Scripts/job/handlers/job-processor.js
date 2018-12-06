/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function startJob(location, args) {
    $.connection.hub.start().done(function () {
        var server = $.connection.streamHub.server;
        server.startJob(location, args).done(function(id) {
            processStartJob(id);
            enableStartJobButton();
        });
    });
}

function stopJob(id) {
    $.connection.hub.start().done(function () {
        var server = $.connection.streamHub.server;
        server.stopJob(id).done(function () {
            removeJob(id);
            createDefaultSign(id);
        });
    });
}

function stopJobs() {
    Object.values(loadAllJobs()).forEach(function(job) {
        stopJob(job.id);
    });
}