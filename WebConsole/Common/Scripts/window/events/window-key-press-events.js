/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function windowContentKeyPressEvent(event) {
    var keyCode = event.keyCode;
    if (keyCode === 13) {
        var input = $(this);
        var value = input.val();

        var container = input.siblings(wcWindowContentOutputClass);
        $.CreateParagraph()
         .append(value)
         .appendTo(container);
        input.val("");

        $.connection.hub.start().done(function () {
            var server = $.connection.streamHub.server;
            server.write(input.data("id"), value).done(function(isSuccessful) {
                if (!isSuccessful) {
                    $.CreateParagraph()
                     .append("The time of existence of the console has come out. Create a new one!")
                     .appendTo(container);
                }
            });
        });
    }
}