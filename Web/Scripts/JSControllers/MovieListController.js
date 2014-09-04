var MovieListController = function(movieListViewModel) {

    var viewModel = movieListViewModel;

    var init = function(selector) {
        selector.each(function () {
            ko.applyBindings(viewModel, this);
        });
    }

    var bindClearBtnTo = function(eventType, selector) {
        selector.on(eventType, function() {
            viewModel.clickClear();
        });
    }

    return {
        init: init,
        viewModel: viewModel,
        bindClearBtnTo: bindClearBtnTo,
    }
};