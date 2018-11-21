/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

$.CreateDiv = function() {
    return $("<div></div>");
};

$.CreateSpan = function() {
    return $("<span></span>");
};

$.CreateParagraph = function() {
    return $("<p></p>");
};

$.CreateLink = function() {
    return $("<a></a>").attr("href", "#");
};

$.CreateOption = function() {
    return $("<option></option>");
};

$.CreateIcon = function (type, name) {
    return $("<i></i>").addClass(type)
                       .addClass(name);
};