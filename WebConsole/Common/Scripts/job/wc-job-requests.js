/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function startJobRequest(handler) {
    processReadRequest("/Job/State/Start", handler);
}

function stopJobRequest(handler) {
    processReadRequest("/Job/State/Stop", handler);
}

function readJobRequest(handler) {
    processReadRequest("/Job/Stream/Read", handler);
}

function writeJobRequest(data) {
    processWriteRequest("/Job/Stream/Write", data);
}