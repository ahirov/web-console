/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function processStartJob(id) {
    var job = loadJob(null);
    if (id > 0) {
        job.id = id;
        job.isActive = true;

        if (job.status.value === null) {
            job.status.value = "Initializing...";
        }
        saveJob(job);
        processWindow(job);
    } else {
        var note = $(wcNoteModalClass);
        note.find(wcModalTitleClass)
            .text("The maximum number of jobs reached!!!");
        note.modal("show");
        setTimeout(function () {
            note.modal("hide");
        }, 2500);
    }
    removeJob(null);
}