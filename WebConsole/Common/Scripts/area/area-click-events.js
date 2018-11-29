/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function areaMinimizeButtonEvent() {
    var id = $(wcAreaClass).data("id");
    var job = loadJob(id);

    createAreaTab(job);
    createDefaultArea();
    return false;
}

function areaMaximizeButtonEvent() {
    var element = $(wcAreaClass).get(0);
    toggleFullScreen(element);
    return false;
}

function areaCloseButtonEvent() {
    stopReadJob();
    return false;
}

function areaRestoreButtonEvent() {
    var tab = $(this).parent();
    var id = tab.data("id");
    tab.remove();

    var job = loadJob(id);
    createArea(job);
    return false;
}