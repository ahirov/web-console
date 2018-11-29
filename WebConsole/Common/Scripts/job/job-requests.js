/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function getAllJobsRequest(handler) {
    processReadRequest("/Job/Global/GetAll", handler);
}

function stopAllJobsRequest(handler) {
    processReadRequest("/Job/Global/StopAll", handler);
}