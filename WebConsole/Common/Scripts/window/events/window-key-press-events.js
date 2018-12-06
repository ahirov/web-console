/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function windowContentKeyPressEvent(event) {
    var keyCode = event.keyCode;
    if (keyCode === 13) {
        var input = $(this);
        var value = input.val();

        $.CreateParagraph()
         .append(value)
         .appendTo(input.siblings(wcWindowContentOutputClass));
        input.val("");

        $.connection.hub.start().done(function () {
            var server = $.connection.streamHub.server;
            server.write(input.data("id"), value);
        });
    }
}