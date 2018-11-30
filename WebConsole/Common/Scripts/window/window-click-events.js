/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function windowMinimizeButtonEvent() {
    var id = $(wcWindowClass).data("id");
    var job = loadJob(id);

    createWindowTab(job);
    createDefaultSign();
    return false;
}

function windowMaximizeButtonEvent() {
    var element = $(wcWindowClass).get(0);
    toggleFullScreen(element);
    return false;
}

function windowCloseButtonEvent() {
    stopJob();
    return false;
}

function windowRestoreButtonEvent() {
    var tab = $(this).parent();
    var id = tab.data("id");
    tab.remove();

    var job = loadJob(id);
    createWindow(job);
    return false;
}