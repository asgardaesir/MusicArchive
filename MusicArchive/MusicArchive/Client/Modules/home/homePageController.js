var homePageController = angular.module('homePageController', ['chart.js', 'angularSpinners']);

homePageController.controller('homePageController', ['$scope', 'statApi', '$stateParams', '$state', 'spinnerService',
    function ($scope, statApi, $stateParam, $state, spinnerService) {

        statApi.highLevelStats.get({}, function(data){
            $scope.stats = data.content;
        });

        statApi.bandsByGenre.get({}, function(data){
            $scope.labelsByGenre = data.genres;
            $scope.dataByGenre = data.counts;
            spinnerService.hide('dashboardGenreSpinner');
        });

        statApi.bandsByCountry.get({}, function(data){
            $scope.labelsByCountry = data.genres;
            $scope.dataByCountry = data.counts;
            spinnerService.hide('dashboardCountrySpinner');
        });

        
        statApi.bandsByStatus.get({}, function(data){
            $scope.labelsByStatus = data.genres;
            $scope.dataByStatus = data.counts;
            spinnerService.hide('dashboardStatusSpinner');
        });

        $scope.CountrySearch = function(points, evt){
            var country = $scope.labelsByCountry[points[0]._index];
            $state.go('search', {countryOfOrigin:country});
        }

        $scope.GenreSearch = function(points, evt){
            var genre = $scope.labelsByGenre[points[0]._index];
            $state.go('search', {genre:genre});
        }

        $scope.StatusSearch = function(points, evt){
            var status = $scope.labelsByStatus[points[0]._index];
            $state.go('search', {countryOfOrigin:status});
        }

         $scope.$on('$viewContentLoaded', function(){
            spinnerService.show('dashboardStatusSpinner');
            spinnerService.show('dashboardGenreSpinner');
            spinnerService.show('dashboardCountrySpinner');
         });
    }
]);