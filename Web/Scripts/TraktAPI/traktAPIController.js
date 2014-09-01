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

    function downloadItems(type) {
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
        searchText = ($scope.searchtext).replace(/\s+/g, "-");
        console.log(searchText);
        console.log(getCorrectJsonToJsonpUrl('movies'));
        $scope.searchData = [];

        downloadItems('movies');
        downloadItems('shows');
    };
    }
]);