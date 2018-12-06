/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function() {
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