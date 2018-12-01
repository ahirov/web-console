/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function windowMinimizeButtonEvent() {
    var id = $(this).data("id");
    var job = loadJob(id);
    job.isActive = false;
    saveJob(job);

    createWindowTab(job);
    createDefaultSign(id);
    return false;
}

function windowMaximizeButtonEvent() {
    var element = $(wcWindowClass).get(0);
    toggleFullScreen(element);
    return false;
}

function windowCloseButtonEvent() {
    var id = $(this).data("id");
    stopJob(id);
    return false;
}

function windowRestoreButtonEvent() {
    var tab = $(this).parent();
    var id = tab.data("id");
    tab.parent().remove();

    var job = loadJob(id);
    job.isActive = true;
    saveJob(job);

    processWindow(job);
    return false;
}