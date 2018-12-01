/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function () {
    $(wcStartJobButtonId).click(function () {
        var info = $(wcJobsListId).find(":selected")
                                  .data("jobInfo");

        var job = new JobContent(info);
        var args = $(wcJobArgsId).val();
        startJob(job, args, function () {
            processWindow(job);
        });
        return false;
    });

    $(wcViewModeButtonId).click(function () {
        var containers = $(wcWindowContainerClass);
        containers.find(wcWindowMinimizeButtonClass)
                  .trigger("click");

        var container = $(wcWindowsContainerId);
        var mode = loadViewMode() === ViewMode.SINGLE
            ? ViewMode.MULTIPLE
            : ViewMode.SINGLE;

        createWindowsContainer(mode, container);
        createDefaultSign();
        saveViewMode(mode);
        return false;
    });
});