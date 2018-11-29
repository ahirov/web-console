/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function startReadJob(job, args, callback) {
    var stream = $.connection.streamHub;
    stream.client.read = function (id, value) {
        var job = loadJob(id);
        if (job.isActive) {
            job.status = "working...";
            $(wcAreaStatusClass).text(job.status);
            $.CreateParagraph()
             .append(value)
             .appendTo($(wcAreaContentOutputClass));
        }
        job.lines.push(value);
        saveJob(job);
    };

    $.connection.hub.start().done(function () {
        stream.server.startJob(job.location,
                               args).done(function (id) {
            job.id = id;
            job.lines = [];
            job.status = "initializing...";
            job.isActive = true;

            saveJob(job);
            callback();
        });
    });
}

function stopReadJob() {
    var id = $(wcAreaClass).data("id");
    var stream = $.connection.streamHub;
    stream.server.stopJob(id).done(function () {
        removeJob(id);
        $.connection.hub.stop();
        createDefaultArea();
    });
}