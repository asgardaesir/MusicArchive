var loginController = angular.module('loginController', []);
loginController.controller('loginController', ['$scope', '$rootScope','$location', 'userApi',
    function($scope, $location, $rootScope, userApi) {
        $scope.userName = '';
        $scope.password = '';
        $scope.loggedIn = false;

        $scope.login = function() {

            var body = 'grant_type=password&username=' + $scope.userName + '&password=' + $scope.password;

            userApi.login.save(body, function(data) {
                console.log('Successful login');
                console.log(data.access_token);
                $scope.loggedIn = true;

                $scope.$emit('loggedIn', {});

                $scope.loggedInUser = $scope.userName;
                sessionStorage.setItem('access_token', data.access_token);
            },
            function(err) {
                console.log(err.data.modelState);
            });
        };
    }
]);