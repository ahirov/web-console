/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

window.isReadJob = false;

function startReadJob() {
    window.isReadJob = true;
    var handler = function (output) {
        // TODO Error!!!
        if (window.isReadJob) {
            $.CreateParagraph()
             .append(output)
             .appendTo($(wcAreaContentOutputClass));
            readJobRequest(handler);
        }
    };
    readJobRequest(handler);
}

function stopReadJob() {
    window.isReadJob = false;
}