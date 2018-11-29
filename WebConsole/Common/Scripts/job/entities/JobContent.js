/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function JobContent(obj) {
    if (obj) {
        this.id       = obj.id;
        this.name     = obj.name;
        this.fullName = obj.fullName;
        this.location = obj.location;
        this.status   = obj.status;
        this.lines    = obj.lines;
        this.isActive = obj.isActive;
    } else {
        this.id       = null;
        this.name     = null;
        this.fullName = null;
        this.location = null;
        this.status   = null;
        this.lines    = [];
        this.isActive = false;
    }
    this.__type__ = ContentType.JOB;
}