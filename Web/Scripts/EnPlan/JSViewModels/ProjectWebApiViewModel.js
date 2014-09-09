function ProjectWebApiViewModel() {
    return {
        "searchId": ko.observable(1),
        "View": ko.observable(0),
        "projNames": ko.observable(),
        "projInfo": ko.observable(),
        "taskList": ko.observableArray(),
    };
}