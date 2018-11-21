/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function getAllJobsRequest(handler) {
    processReadRequest("/Job/Global/GetAll", handler);
}

function startJobRequest(data, handler) {
    processRequest("/Job/State/Start", data, handler);
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