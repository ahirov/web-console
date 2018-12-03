/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function getAllJobsRequest(handler) {
    processReadRequest("/Job/Global/GetAll", handler);
}

function stopAllJobsRequest(data, handler) {
    processRequest("/Job/Global/StopAll", false, data, handler);
}