'use strict';

var musicArchiveApp = angular.module('MusicArchiveApp',
    [
        'ngResource',
        'ui.router',
        'ngTagsInput',
        'bandPageController',
        'bandListController',
        'navigationController',
        'searchController',
        'homePageController',
        'loginController',
        'registrationController',
        'addBandController',
        'menuController',
        'albumDetailController',
        'chart.js',
        'ui.bootstrap',
        'angularSpinners'
    ]
);

musicArchiveApp.factory('authInterceptorService', ['$q', '$rootScope',
    function($q, $rootscope) {
        return {
            request: function(config) {
                if(sessionStorage.getItem('access_token') !== null) {
                    config.headers.Authorization = 'Bearer ' + sessionStorage.getItem('access_token');
                }

                return config;
            }
        }
    }
]);

musicArchiveApp.config(['$stateProvider', '$urlRouterProvider', '$httpProvider', function($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
    
    var homeState = {
        name: 'home',
        url: '/home',
        templateUrl: './modules/home/homeView.html',
        controller: 'homePageController'
    };

    var searchState = {
        name: 'search',
        url: '/search',
        templateUrl: './modules/search/SearchBandsView.html',
        controller: 'bandListController',
        params: {
            id: null,
            bandName : '',
            genre: '',
            yearOfFormation: '',
            countryOfOrigin: '',
            lyricalThemes: '',
            label: '',
            startingRecordNumber: 0
        }
    };

    var viewBandState = {
        name: 'viewBand',
        url: '/Band/:id',
        templateUrl: './modules/band/bandView.html',
        controller: 'bandPageController',
        params: {
            id: null,
            
        }
    };

    var addBandState = {
        name: 'addBand',
        url: '/addBand',
        templateUrl: './modules/band/addBandView.html',
        controller: 'addBandController'
    };

    var albumViewState = {
        name: 'viewAlbum',
        url: '/Album/:id',
        templateUrl: './modules/album/albumDetailView.html',
        controller: 'albumDetailController',
        params: {
            id: null
        }
    };

     $stateProvider.state(homeState);
     $stateProvider.state(albumViewState);
     $stateProvider.state(addBandState);
     $stateProvider.state(searchState);
     $stateProvider.state(viewBandState);

     $urlRouterProvider.otherwise(function($injector) {
        var $state = $injector.get('$state');
        $state.go('home');
    });
}]);

musicArchiveApp.factory('bandApi', function($resource) {
    return $resource('../api/Band/:id');
});

// stats could be done by sending the filter property server side rather than having mutiple api's
musicArchiveApp.factory('statApi', function($resource) {
    return {
        highLevelStats: $resource('../api/stats'),
        bandsByCountry: $resource('../api/stats/GetByCountry'),
        bandsByGenre: $resource('../api/stats/GetByGenre'),
        bandsByStatus: $resource('../api/stats/GetByStatus')
    }
});

musicArchiveApp.factory('albumApi', function($resource){
    return {
        album: $resource('../api/Album/:id'),
        review: $resource('../api/album/review', {}, {
            save: {
                method: 'POST'
            }
        })
    }
});

musicArchiveApp.factory('userApi', function($resource) {
    return {
        login: $resource('../Token', {}, {
            save: {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                }
            }
        }),
        register: $resource('../api/account/register')
    }
});

musicArchiveApp.factory('searchApi', function($resource) {
    return $resource('../api/Search/search/:t');
});