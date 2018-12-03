/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function startJob(job, args, callback) {
    var stream = $.connection.streamHub;
    stream.client.read = function (id, value) {
        var job = loadJob(id);
        if (job.isActive) {
            var container = getWindowContainer(job.id);
            var status = job.status;
            if (!status.isError) {
                status.value = "Working...";
                updateWindowFooter(status, container);
            }
            $.CreateParagraph()
             .append(value)
             .appendTo(container.find(wcWindowContentOutputClass));
        }
        job.lines.push(value);
        saveJob(job);
    };
    stream.client.stop = function (id) { stopJob(id); };
    stream.client.error = function (id, message) {
        var job = loadJob(id);
        var status = job.status;
        if (status.isError) {
            status.error = status.error
                + "<br>"
                + message.replace(" in ", "<br>in ");
        } else {
            status.value = "Error!!!";
            status.error = message;
            status.isError = true;
        }
        saveJob(job);
        var container = getWindowContainer(job.id);
        updateWindowFooter(status, container);
    };

    $.connection.hub.start().done(function () {
        stream.server.startJob(job.location,
                               args).done(function (id) {
            job.id = id;
            job.lines = [];
            job.status.value = "Initializing...";
            job.isActive = true;

            saveJob(job);
            callback();
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