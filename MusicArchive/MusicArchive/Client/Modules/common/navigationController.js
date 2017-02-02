var navigationController = angular.module('navigationController', []);
navigationController.controller('navigationController', ['$scope', '$location',
    function($scope, $location){
       $scope.changeView = function (hash) {
	        $location.path(hash);
	    };
    }
]);