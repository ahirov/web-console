/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function startJobRequest(handler) {
    processReadRequest("/Job/Start", handler);
}

function stopJobRequest(handler) {
    processReadRequest("/Job/Stop", handler);
}

function readJobRequest(handler) {
    processReadRequest("/Job/Read", handler);
}

function writeJobRequest(data) {
    processWriteRequest("/Job/Write", data);
}