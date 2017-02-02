'use strict';

var registrationController = angular.module('registrationController', []);
registrationController.controller('registrationController', ['$scope', 'userApi',
    function($scope, userApi) {
        $scope.userName = '';
        $scope.email = '';
        $scope.password = '';
        $scope.confirmPassword = '';


          $scope.register = function() {
            userApi.register.save({email:$scope.email,password:$scope.password,confirmPassword:$scope.confirmPassword}, function(data) {
                console.log('Successful registration');
            },
            function(err) {

                $scope.errors = [];
                $scope.errorMessage = ""

                Object.values(err.data.modelState).forEach(
                    function(error) {
                        $scope.errors.push(error);
                    }
                );

                $scope.errors = $scope.errors.reduce( ( acc, cur ) => acc.concat(cur), [] );

                console.log($scope.errors);
            });
        };
    }
])
.directive('registration', function() {
    return {
        templateUrl: './modules/common/registrationView.html',
         transclude: true
    };
});