/* WebConsole (https://github.com/hirov-anton/web-console)
See LICENSE file in the solution root for full license information
Copyright (c) 2018 Anton Hirov */

function saveJob(job) {
    var storage = loadStorage();
    storage.jobs[job.id] = job;

    saveStorage(storage);
}

function loadAllJobs() {
    return loadStorage().jobs;
}

function loadJob(id) {
    return loadAllJobs()[id];
}

function removeJob(id) {
    var storage = loadStorage();

    delete storage.jobs[id];
    saveStorage(storage);
}