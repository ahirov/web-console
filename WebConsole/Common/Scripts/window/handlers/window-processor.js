/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createWindow(job, rawContainer) {
    var id = job.id;
    var container = rawContainer.empty()
                                .data("id", id);
    var window = $.CreateDiv()
                  .addClass(wcWindowClass.GetName())
                  .hide()
                  .appendTo(container);
    createWindowHeader(id, job.fullName, window);
    createWindowContent(id, job.lines, window);
    createWindowFooter(job.status, window);

    window.fadeIn();
}

function processWindow(job) {
    var isSuccessful = false;
    var containers = $(wcWindowContainerClass);
    containers.each(function () {
        var container = $(this);
        if (!container.data("id")) {
            createWindow(job, container);
            isSuccessful = true;
            return false;
        }
    });
    if (!isSuccessful) {
        var lastContainer = containers.last();
        lastContainer.find(wcWindowMinimizeButtonClass)
                     .trigger("click");
        createWindow(job, lastContainer);
    }
}