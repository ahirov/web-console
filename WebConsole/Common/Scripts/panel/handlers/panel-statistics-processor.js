/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function processStatisticsModal(descriptions) {
    var window = $(wcWindowModalClass);
    var container = window.find(wcModalContentClass)
                          .empty();
    if (descriptions.length) {
        descriptions.forEach(function (value, index) {
            var description = ++index
                              + ". "
                              + value.name
                              + " (" + value.startTime + ")";
            $.CreateParagraph()
             .append(description)
             .appendTo(container);
        });
    } else {
        $.CreateParagraph()
         .append("There is nothing to show here!")
         .appendTo(container);
    }
    window.modal("show");
}