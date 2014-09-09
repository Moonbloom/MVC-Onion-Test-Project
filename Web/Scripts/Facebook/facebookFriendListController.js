var facebookFriendListController = angular.module('facebookFriendListController', []);
var accessToken = "";
var showFriends = false;

facebookFriendListController.controller('facebookFriendListController', ['$scope', function ($scope) {
        $scope.facebookLoginButton = function() {
            FB.getLoginStatus(function(response) {
                if (response.status === 'connected') {
                    login_event(response);
                } else {
                    FB.login(login_event, { scope: 'user_friends' });
                }
            });
        };

        $scope.facebookLogoutButton = function() {
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    FB.logout();
                    accessToken = "";
                    $scope.friendList = [];
                }
            });
        };

        $scope.checkAccessToken = function() {
            console.log(accessToken);
        };

        $scope.getMe = function() {
            FB.api('/me', function (response) {
                showFriends = false;
                console.log(JSON.stringify(response));
            });
        };

        $scope.getFriends = function () {
            FB.api('/me/friends', function (response) {
                showFriends = true;
                console.log(JSON.stringify(response));
                $scope.friendList = response.data;
                $scope.$apply();
            });
        };

        $scope.showFriendsList = function() {
            return showFriends;
        };
    }
]);

$(document).ready(function () {
    window.fbAsyncInit = function () {
        FB.init({
            appId: '1421383058109198',
            xfbml: false,
            version: 'v1.0',
        });

        //FB.Event.subscribe('auth.login', login_event);

        FB.getLoginStatus(function (response) {
            if (response.status === 'connected') {
                login_event(response);
            }
        });
    };

    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/da_DK/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));
});

var login_event = function (response) {
    console.log(response);
    accessToken = response.authResponse.accessToken;
};