var ProjectWebApiController = function (backend, projectViewModel, notify) {

    var viewModel = projectViewModel;

    var init = function(selector) {
        selector.each(function() {
            ko.applyBindings(viewModel, this);
        });
    };

    var bindGetProjectNamesBtnTo = function (eventType, selector) {
        selector.on(eventType, function () {
            notify.info("Retrieving project names ...");
            backend.GetAllProjectNames().done(function (response) {
                console.log(response);
            });
        });
    };

    var bindGetProjectInfoBtnTo = function (eventType, selector) {
        selector.on(eventType, function () {
            notify.info("Retrieving chosen project information ...");
            backend.GetProjectInfo(viewModel.searchId()).done(function (response) {
                console.log(response);
            });
        });
    };

    return {
        init: init,
        viewModel: viewModel,
        bindGetProjectNamesBtnTo: bindGetProjectNamesBtnTo,
        bindGetProjectInfoBtnTo: bindGetProjectInfoBtnTo
    };
};