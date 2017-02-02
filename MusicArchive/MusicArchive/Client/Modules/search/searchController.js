var searchController = angular.module('searchController', []);
searchController.controller('searchController', ['$scope','$location', 'searchApi', '$state',
    function($scope, $location, searchApi, $state) {

        $scope.searchOptions = {
            bandName : '',
            genre: '',
            yearOfFormation: '',
            countryOfOrigin: '',
            lyricalThemes: '',
            label: ''
        }

        $scope.hasResults = false;

        $scope.search = function() {
            searchApi.query($scope.searchOptions, function(data) {
                $scope.bands = data;
                console.log(data);

                if(data.length > 0) {
                    $scope.hasResults = true;
                    $scope.noResults = false;
                    console.log("Search had results");
                } else {
                    $scope.noResults = true;
                    $scope.hasResults = false;
                }
            });
        }

        $scope.changeView = function (hash) {
	        $location.path(hash);
	    };

        $scope.goToBand = function(bandId) {
            $state.go('viewBand', {id:bandId})
        }
    }
]);
