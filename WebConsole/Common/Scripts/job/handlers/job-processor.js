/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function startJob(job, args) {
    var stream = $.connection.streamHub;
    stream.client.read = processReadJob;
    stream.client.stop = function (id) { stopJob(id); };
    stream.client.error = processStopJob;

    $.connection.hub.start().done(function () {
        stream.server.startJob(job.location, args)
                     .done(function (id) {
            processStartJob(id, job);
        });
    });
}

function stopJob(id) {
    var stream = $.connection.streamHub;
    stream.server.stopJob(id).done(function () {
        removeJob(id);
        createDefaultSign(id);
    });
}

function stopJobs() {
    Object.values(loadAllJobs()).forEach(function(job) {
        stopJob(job.id);
    });
}