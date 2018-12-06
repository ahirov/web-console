/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function processReadJob(id, value) {
    var job = loadJob(id);
    job.lines.push(value);

    var status = job.status;
    if (!status.isError) {
        status.value = "Working...";
    }
    saveJob(job);
    if (job.isActive) {
        var container = getWindowContainer(job.id);
        updateWindowFooter(status, container);

        $.CreateParagraph()
         .append(value)
         .appendTo(container.find(wcWindowContentOutputClass));
    }
}