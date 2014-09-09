var FacebookController = function (projectViewModel, notify) {

    var viewModel = projectViewModel;

    var init = function (selector) {
        selector.each(function () {
            ko.applyBindings(viewModel, this);
        });
    };

    var bindClearBtnTo = function (eventType, selector) {
        selector.on(eventType, function () {
            viewModel.View(0);
            notify.info("List has been cleared");
        });
    };

    var bindFacebookLoginButtonTo = function (eventType, selector) {
        selector.on(eventType, function () {
            console.log("login");
        });
    };

    var bindFacebookLogoutButtonTo = function (eventType, selector) {
        selector.on(eventType, function () {
            console.log("logout");
        });
    };

    var bindCheckAccessTokenTo = function(eventType, selector) {
        selector.on(eventType, function() {
            console.log("check access token");
        });
    }

    var bindGetMeDataTo = function(eventType, selector) {
        selector.on(eventType, function () {
            viewModel.View(2);
            console.log("get me data");
        });
    }

    var bindGetFriendsDataTo = function(eventType, selector) {
        selector.on(eventType, function () {
            viewModel.View(1);
            console.log("get friends data");
        });
    }

    return {
        init: init,
        viewModel: viewModel,
        bindClearBtnTo: bindClearBtnTo,
        bindFacebookLoginButtonTo: bindFacebookLoginButtonTo,
        bindFacebookLogoutButtonTo: bindFacebookLogoutButtonTo,
        bindCheckAccessTokenTo: bindCheckAccessTokenTo,
        bindGetMeDataTo: bindGetMeDataTo,
        bindGetFriendsDataTo: bindGetFriendsDataTo,
    };
};