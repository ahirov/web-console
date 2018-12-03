/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function JobStatus(obj) {
    if (obj) {
        this.value   = obj.value;
        this.error   = obj.error;
        this.isError = obj.isError;
    } else {
        this.value   = null;
        this.error   = null;
        this.isError = false;
    }
    this.__type__ = ContentType.STATUS;
}