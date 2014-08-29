var traktAPIController = angular.module('traktAPIController', []);

traktAPIController.controller('traktAPIController', ['$scope', "$http", function ($scope, $http) {

    var searchText = "";
    var apiKey = '02110f747fe9f8d587f31452403d5e69';
    $scope.searchData = [];

    function getCorrectTraktTvUrl(type) {
        return 'http://api.trakt.tv/search/' + type + '.json' + '/' + apiKey + '?query=' + searchText;
    };

    function getCorrectJsonToJsonpUrl(type) {
        return 'http://json2jsonp.com/?url=' + getCorrectTraktTvUrl(type) + '&callback=JSON_CALLBACK';
    };

    function downloadBothMoviesAndSeries(type) {
        $http.jsonp(getCorrectJsonToJsonpUrl(type)).success(function (data) {
            if (type === 'shows') {
                angular.forEach(data, function (value, key) {
                    value.type = 'Show';
                    $scope.searchData.push(value);
                });
            }
            else {
                angular.forEach(data, function (value, key) {
                    value.type = 'Movie';
                    $scope.searchData.push(value);
                });
            }
        }).error(function (data, status) {
            alert(data, status);
        });
    }

    $scope.getData = function() {
        //var today = new Date();
        //Create the date string and ensure leading zeros if required
        //var apiDate = today.getFullYear() + ("0" + (today.getMonth() + 1)).slice(-2) + "" + ("0" + today.getDate()).slice(-2);
        //$http.jsonp('http://api.trakt.tv/calendar/premieres.json' + '/02110f747fe9f8d587f31452403d5e69' + '/' + apiDate + '/' + 30 + '/?callback=JSON_CALLBACK').success(function(data) {

        searchText = ($scope.searchtext).replace(/\s+/g, "+");
        console.log(searchText);
        console.log(getCorrectJsonToJsonpUrl('movies'));
        $scope.searchData = [];

        downloadBothMoviesAndSeries('movies');
        downloadBothMoviesAndSeries('shows');
    };
    }
]);