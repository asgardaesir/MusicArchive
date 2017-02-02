'use strict';

var menuController = angular.module('menuController', []);

menuController.controller('menuController', ['$rootScope', '$scope',
    function($scope, $rootscope) {
        $scope.$on('loggedIn', function(event, args){
            $scope.loggedIn = true;
        });
    }
])
.directive('mamenu', function() {
    return {
         templateUrl: './modules/common/navMenuView.html',
         transclude: true
    };
});