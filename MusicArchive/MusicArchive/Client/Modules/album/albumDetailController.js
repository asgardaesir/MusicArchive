'use strict';

var albumDetailController = angular.module('albumDetailController', []);
albumDetailController.controller('albumDetailController', ['albumApi', '$stateParams', '$scope',
    function(albumApi, $stateParams, $scope) {
        
        $scope.reviewText = '';
        $scope.reviewValue;

        albumApi.album.get({id:$stateParams.id}, function(data) {
            $scope.album = data;
        });

        $scope.submitReview = function() {
            albumApi.review.save({id:$scope.album.id, reviewText:$scope.reviewText,rating:$scope.reviewValue}, function() {
                console.log('review submitted');
            });
        };
    }
]);