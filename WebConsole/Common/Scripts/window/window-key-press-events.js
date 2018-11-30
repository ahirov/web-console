/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function windowContentKeyPressEvent(event) {
    var keyCode = event.keyCode;
    if (keyCode === 13) {
        var input = $(wcWindowContentInputClass).val();
        $.CreateParagraph()
         .append(input)
         .appendTo($(wcWindowContentOutputClass));

        $(wcWindowContentInputClass).val("");

        var id = $(wcWindowClass).data("id");
        var stream = $.connection.streamHub;
        stream.server.write(id, input);
    }
}