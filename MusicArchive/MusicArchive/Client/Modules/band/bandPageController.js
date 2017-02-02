var bandPageController = angular.module('bandPageController', []);
bandPageController.controller('bandPageController', ['$scope', 'bandApi', '$stateParams', '$state',
    function ($scope, bandApi, $stateParams, $state) {
        bandApi.get({id:$stateParams.id}, function(data) {
            $scope.band = data;
        });
        
         $scope.goToAlbum = function(albumId) {
            $state.go('viewAlbum', {id:albumId})
        }
    }
]);