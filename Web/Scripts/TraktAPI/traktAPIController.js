var traktAPIController = angular.module('traktAPIController', []);

traktAPIController.controller('traktAPIController', ['$scope', "$http", function ($scope, $http) {

    $scope.getData = function () {
        //var today = new Date();
        //Create the date string and ensure leading zeros if required
        //var apiDate = today.getFullYear() + ("0" + (today.getMonth() + 1)).slice(-2) + "" + ("0" + today.getDate()).slice(-2);
        //$http.jsonp('http://api.trakt.tv/calendar/premieres.json' + '/02110f747fe9f8d587f31452403d5e69' + '/' + apiDate + '/' + 30 + '/?callback=JSON_CALLBACK').success(function(data) {
        $http.jsonp('http://api.trakt.tv/search/shows.json' + '/02110f747fe9f8d587f31452403d5e69' + '?query=' + $scope.searchtext + '/?callback=JSON_CALLBACK').success(function (data) {
            console.log(data);

            $scope.search = data;
        }).error(function (error) {
            alert(error);
        });
    }
    }
]);