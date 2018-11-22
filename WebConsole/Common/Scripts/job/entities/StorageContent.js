/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function StorageContent(obj) {
    if (obj) {
        this.jobs = obj.jobs;
    } else {
        this.jobs = {};
    }
    this.__type__ = ContentType.STORAGE;
}