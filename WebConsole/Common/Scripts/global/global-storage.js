/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function saveStorage(storage) {
    var data = JSON.stringify(storage);
    window.sessionStorage.setItem("storage", data);
}

function loadStorage() {
    var data = window.sessionStorage.getItem("storage");
    if (data) {
        return JSON.parse(data, parseStorageContent);
    } else {
        return new StorageContent();
    }
}

function clearStorage() {
    window.sessionStorage.clear();
}

function parseStorageContent(key, value) {
    if (typeof value === "object" && value !== null) {
        var type = value.__type__;
        if (type === ContentType.STORAGE) {
            return new StorageContent(value);
        } else if (type === ContentType.JOB) {
            return new JobContent(value);
        }
    }
    return value;
}