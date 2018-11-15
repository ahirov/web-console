/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function processRequest(url, handler) {
    $.ajax({
        type: "POST",
        url: getOriginUrl() + url,
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
    // TODO Add Error processor!!!
    //window.location.href = getOriginUrl() + "/Error";
}