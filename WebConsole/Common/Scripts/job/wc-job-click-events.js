﻿/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$(document).ready(function() {
    $(wcStartJobButtonId).click(function () {
        startJobRequest(function() {
            $(wcOutputContainerId).append("<p>Console started!!!</p>");
        });
    });

    $(wcStopJobButtonId).click(function () {
        stopJobRequest(function() {
            $(wcOutputContainerId).append("<p>Console stopped!!!</p>");
        });
    });
});