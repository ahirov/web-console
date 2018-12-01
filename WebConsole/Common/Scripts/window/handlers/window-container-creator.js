/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function createWindowsContainer(mode, container) {
    container.empty();
    if (mode === ViewMode.SINGLE) {
        var rootLine = $.CreateDiv()
                        .addClass("row")
                        .appendTo(container);
        var rootCell = $.CreateDiv()
                        .addClass("col-12")
                        .addClass("offset-lg-2")
                        .addClass("col-lg-8")
                        .appendTo(rootLine);
        $.CreateDiv()
         .addClass(wcWindowContainerClass.GetName())
         .appendTo(rootCell);
    } else if (mode === ViewMode.MULTIPLE) {
        for (var i = 0; i < 2; i++) {
            var line = $.CreateDiv().addClass("row").appendTo(container);
            for (var j = 0; j < 2; j++) {
                var cell = $.CreateDiv().addClass("col-md-6").appendTo(line);
                $.CreateDiv()
                 .addClass(wcWindowContainerClass.GetName())
                 .appendTo(cell);
            }
        }
    }
}