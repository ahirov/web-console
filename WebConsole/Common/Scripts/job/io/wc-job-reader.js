/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

window.isReadJob = false;

function startReadJob() {
    window.isReadJob = true;
    $(wcJobInputId).prop("disabled", false);
    var handler = function (output) {
        if (window.isReadJob) {
            $(wcOutputContainerId).append("<p>" + output + "</p>");
            readJobRequest(handler);
        }
    };
    readJobRequest(handler);
}

function stopReadJob() {
    window.isReadJob = false;
    $(wcJobInputId).prop("disabled", true);
}