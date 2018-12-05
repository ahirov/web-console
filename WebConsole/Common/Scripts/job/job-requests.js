/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function getJobInfosRequest(handler) {
    processReadRequest("/Job/Global/GetInfos", handler);
}

function getJobStatisticsReguest(handler) {
    processReadRequest("/Job/Global/GetStatistics", handler);
}

function stopOwnJobsRequest(data, handler) {
    processRequest("/Job/Global/StopAllOwn", false, data, handler);
}