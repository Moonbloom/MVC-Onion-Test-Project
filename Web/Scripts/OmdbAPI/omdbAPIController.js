var omdbAPIController = angular.module('omdbAPIController', []);

omdbAPIController.controller('omdbAPIController', ['$scope', "$http", function ($scope, $http) {
    //ItemsService.query(function (data) {
    //        console.log(data);

    //        $scope.Search = data.Search;
    //});

        $scope.getData = function() {
            $http.get('http://www.omdbapi.com/?s=' + $scope.searchtext).success(function(data) {
                $scope.search = data.Search;

                console.log(data);
            }).error(function(error) {
                alert(error);
            });
        };
    }
]);