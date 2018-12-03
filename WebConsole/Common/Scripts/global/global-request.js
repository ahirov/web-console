/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function processReadRequest(url, handler) {
    processRequest(url, true, null, handler);
}

function processWriteRequest(url, data) {
    processRequest(url, true, data, null);
}

function processRequest(url, isAsync, data, handler) {
    $.ajax({
        type: "POST",
        async: isAsync,
        url: getOriginUrl() + url,
        data: data,
        success: function (result) {
            processSuccess(result, handler);
        },
        error: processError
    });
}

function processSuccess(result, handler, parameters) {
    if (result.url) {
        window.location.href = result.url;
    } else if (result.data && handler) {
        handler(result.data, parameters);
    }
}

function processError() {
    window.location.href = getOriginUrl() + "/Error/Critical";
}