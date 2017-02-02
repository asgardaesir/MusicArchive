var bandListController = angular.module('bandListController', []);
bandListController.controller('bandListController', ['$scope', '$location',
    function($scope, $location){
       $scope.changeView = function (hash) {
	        $location.path(hash);
	    };
    }
]);