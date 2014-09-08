var MovieListController = function(movieListViewModel, notify) {

    var viewModel = movieListViewModel;
    var apiKey = '02110f747fe9f8d587f31452403d5e69';
    var lastSearchText;

    var init = function(selector) {
        selector.each(function () {
            ko.applyBindings(viewModel, this);
        });
    }

    var bindClearBtnTo = function(eventType, selector) {
        selector.on(eventType, function () {
            if (viewModel.movieList() != null && viewModel.movieList().length > 0) {
                notify.info("The list has been cleared");
            }
            viewModel.movieList(null);
            viewModel.searchText(null);
            
        });
    }

    var bindDropdownBtnTo = function (eventType, selector) {
        selector.on(eventType, function (data) {
            viewModel.chosenDropDownItemName(data.toElement.innerHTML);
            searchForData();
        });
    }

    viewModel.searchText.subscribe(function (newValue) {
        lastSearchText = newValue;
        searchForData();
    });

    //private
    function searchForData() {
        if (lastSearchText != undefined) {
            var fixedSearchText = (lastSearchText.trim()).replace(/\s+/g, "-");
            $.getJSON(getCorrectJsonToJsonpUrl(viewModel.chosenDropDownItemName(), fixedSearchText), {}, function (data) {
                if (viewModel.chosenDropDownItemName() === 'Shows') {
                    for (x in data) {
                        data[x].type = 'Show';
                    }
                }
                else {
                    for (x in data) {
                        data[x].type = 'Movie';
                    }
                }

                viewModel.movieList(data);
            });
        } else {
            console.log("newValue is undefined");
        }
    }

    //private
    function getCorrectTraktTvUrl(type, searchQuery) {
        return 'http://api.trakt.tv/search/' + type + '.json' + '/' + apiKey + '?query=' + searchQuery;
    };

    //private
    function getCorrectJsonToJsonpUrl(type, searchQuery) {
        return 'http://json2jsonp.com/?url=' + getCorrectTraktTvUrl(type, searchQuery) + '&callback=?';
    };

    return {
        init: init,
        viewModel: viewModel,
        bindClearBtnTo: bindClearBtnTo,
        bindDropdownBtnTo: bindDropdownBtnTo
    }
};