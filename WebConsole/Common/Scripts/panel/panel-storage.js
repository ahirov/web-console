/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function saveViewMode(mode) {
    var storage = loadStorage();
    storage.view.mode = mode;

    saveStorage(storage);
}

function loadViewMode() {
    return loadStorage().view.mode;
}