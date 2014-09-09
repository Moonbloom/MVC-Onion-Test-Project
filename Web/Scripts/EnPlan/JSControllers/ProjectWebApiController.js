var ProjectWebApiController = function (backend, projectViewModel, notify) {

    var viewModel = projectViewModel;

    var init = function(selector) {
        selector.each(function() {
            ko.applyBindings(viewModel, this);
        });
    };

    var bindGetProjectNamesBtnTo = function (eventType, selector) {
        selector.on(eventType, function () {
            viewModel.View(1);
            notify.info("Retrieving project names ...");
            backend.GetAllProjectNames().done(function (response) {
                viewModel.projNames(response);
            });
        });
    };

    var bindGetProjectInfoBtnTo = function (eventType, selector) {
        selector.on(eventType, function () {
            viewModel.View(2);
            notify.info("Retrieving chosen project information ...");
            backend.GetProjectInfo(viewModel.searchId()).done(function (response) {
                viewModel.projInfo(response);
                viewModel.taskList(response.Tasks);
            });
        });
    };

    var bindClearBtnTo = function(eventType, selector) {
        selector.on(eventType, function() {
            viewModel.View(0);
            notify.info("List has been cleared");
        });
    };

    return {
        init: init,
        viewModel: viewModel,
        bindGetProjectNamesBtnTo: bindGetProjectNamesBtnTo,
        bindGetProjectInfoBtnTo: bindGetProjectInfoBtnTo,
        bindClearBtnTo: bindClearBtnTo
    };
};