/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function startJobRequest(handler) {
    processRequest("/Job/Start", handler);
}

function stopJobRequest(handler) {
    processRequest("/Job/Stop", handler);
}