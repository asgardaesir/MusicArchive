var homePageController = angular.module('homePageController', ['chart.js']);

homePageController.controller('homePageController', ['$scope', 'statApi', '$stateParams',
    function ($scope, statApi, $stateParams) {

        statApi.highLevelStats.get({}, function(data){
            $scope.stats = data.content;
        });

        statApi.bandsByGenre.get({}, function(data){
            $scope.labelsByGenre = data.genres;
            $scope.dataByGenre = data.counts;
        });

        statApi.bandsByCountry.get({}, function(data){
            $scope.labelsByCountry = data.genres;
            $scope.dataByCountry = data.counts;
        });

        statApi.bandsByStatus.get({}, function(data){
            $scope.labelsByStatus = data.genres;
            $scope.dataByStatus = data.counts;
        });
    }
]);