/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function enableStartJobButton() {
    $(wcStartJobButtonId).off("click")
                         .removeClass("disabled")
                         .click(startJobButtonEvent);
}

function disableStartJobButton() {
    $(wcStartJobButtonId).off("click")
                         .addClass("disabled")
                         .click(startJobDisabledButtonEvent);
}