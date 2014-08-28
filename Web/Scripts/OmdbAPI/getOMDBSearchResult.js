var OMDBService = angular.module('OMDBService', ['ngResource']);

OMDBService.factory('OMDBService', ['$resource',
    function ($resource) {
        return $resource('http://www.omdbapi.com/?s=', {}, {
            query: { method: 'GET', params: {}, isArray: false}
        });
    }]);