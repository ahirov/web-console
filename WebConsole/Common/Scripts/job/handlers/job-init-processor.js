/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function initJobStreamHub() {
    var stream = $.connection.streamHub;
    stream.client.read = processReadJob;
    stream.client.stop = function (id) { stopJob(id); };
    stream.client.error = processStopJob;
}