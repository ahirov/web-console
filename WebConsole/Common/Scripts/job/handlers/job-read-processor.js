/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function processReadJob(id, value) {
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
}