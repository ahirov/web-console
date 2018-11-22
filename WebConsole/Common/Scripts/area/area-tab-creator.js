/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */


function createAreaTab(job) {
    var tab = $.CreateDiv()
               .data("id", job.id)
               .addClass("d-flex")
               .addClass("col-md-4")
               .addClass("col-lg-3")
               .addClass("col-xl-2")
               .hide();

    $.CreateSpan()
     .addClass("mr-auto")
     .append(job.name)
     .appendTo(tab);
    $.CreateLink()
     .append($.CreateIcon("far", "fa-window-restore"))
     .appendTo(tab)
     .click(areaRestoreButtonEvent);

    $(wcTabContainerId).append(tab);
    tab.fadeIn();
}