var searchController = angular.module('searchController', ['angularSpinners']);
searchController.controller('searchController', ['$scope','$location', 'searchApi', '$state', '$stateParams', 'spinnerService',
    function($scope, $location, searchApi, $state, $stateParams, spinnerService) {

        $scope.currentPage = 0;

        $scope.search = function() {
            $scope.bands;

            spinnerService.show('searchingSpinner');
            searchApi.get($scope.searchOptions, function(data) {
                $scope.bands = data.searchResults;
                $scope.resultCount = data.results;

                $scope.pageCount = new Array(Math.ceil(data.results / 50)); // Work around for angular not allowing ng-repeat off a number

                if(data.length > 0) {
                    $scope.noResults = false;
                    console.log("Search had results");
                } else {
                    $scope.noResults = true;
                }

                spinnerService.hide('searchingSpinner');
            });
        }

        $scope.getResultsForPage = function(page) {
            console.log('getting page: ' + page);
            $scope.currentPage = page;
            $scope.bands = undefined;

            spinnerService.show('searchingSpinner');

            $scope.searchOptions.startingRecordNumber = page * 50; // get page count from request!!

            searchApi.get($scope.searchOptions, function(data) {
                $scope.bands = data.searchResults;
                $scope.resultCount = data.results;

                $scope.pageCount = new Array(Math.ceil(data.results / 50)); // Work around for angular not allowing ng-repeat off a number

                if(data.length > 0) {
                    $scope.noResults = false;
                    console.log("Search had results");
                } else {
                    $scope.noResults = true;
                }

                spinnerService.hide('searchingSpinner');
            });
        }

        $scope.changeView = function (hash) {
	        $location.path(hash);
	    };

        $scope.goToBand = function(bandId) {
            $state.go('viewBand', {id:bandId});
        }

        var hasValues = function checkProperties(obj) {
            for (var key in obj) {
                if (obj[key] !== null && obj[key] != "")
                    return false;
            }
            return true;
        }

        console.log($stateParams);

        if(!hasValues($stateParams)){
            console.log("Had search parameters");
            $scope.searchOptions = $stateParams;
            $scope.search();
        }else{
            console.log("Had no search parameters");
            $scope.searchOptions = {
                bandName : '',
                genre: '',
                yearOfFormation: '',
                countryOfOrigin: '',
                lyricalThemes: '',
                label: '',
                startingRecordNumber: 0
            }
        }
    }
]);
