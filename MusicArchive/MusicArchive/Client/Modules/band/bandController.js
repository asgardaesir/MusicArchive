'use strict';

var addBandController = angular.module('addBandController', ['ngTagsInput']);
addBandController.controller('addBandController', ['$scope', 'bandApi',
    function($scope, restApi) {

        $scope.newBand = {
            name:'',
            genre:'',
            yearOfFormation:'',
            countryOfOrigin:'',
            lyricalThemes:[],
            lablel:''
        };

        $scope.addBand = function() {
             $scope.newBand.lyricalThemes = $scope.lyricalThemes; // work around for tags as tags-input wont work with object needs to be array only

            bandApi.save($scope.newBand, function(data) {
                console.log('Successful addition of band');
            },
            function(error) {
                console.log(error);
                $scope.error = error.data.message;
            });
        };
    }
]);