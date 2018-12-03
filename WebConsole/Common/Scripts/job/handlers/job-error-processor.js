/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function processStopJob(id, message) {
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
    var container = getWindowContainer(job.id);
    updateWindowFooter(status, container);
    saveJob(job);
}