/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function ViewContent(obj) {
    if (obj) {
        this.mode = obj.mode;
    } else {
        this.mode = ViewMode.SINGLE;
    }
    this.__type__ = ContentType.VIEW;
}