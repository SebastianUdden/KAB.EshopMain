var eShopApp = angular.module('eShopApp', ['ngRoute', 'ngResource']);

eShopApp.config(function($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'pages/home.html',
        controller: 'homeController'
    })

    .when('/admin', {
        templateUrl: 'pages/admin.html',
        controller: 'adminController'
    })

    .when('/search-results/', {
        templateUrl: 'pages/searchResults.html',
        controller: 'searchQueryController'
    })

    .when('/dev-links', {
        templateUrl: 'pages/devLinks.html',
        controller: 'devLinksController'
    })
});

eShopApp.service('cityService', function() {
    this.searchResult = "";
});

eShopApp.controller('headerController', ['$scope', 'cityService', function ($scope, cityService) {
    $scope.searchResult = cityService.searchResult;

    $scope.$watch('searchResult', function () {
        cityService.searchResult = $scope.searchResult;
    });
}]);


eShopApp.controller('homeController', ['$scope', 'cityService', function($scope, cityService) {
}]);

//eShopApp.controller('adminController', ['$scope', function($scope) {
//}]);

eShopApp.controller('searchQueryController', ['$scope', '$resource', 'cityService', function($scope, $resource, cityService) {
    $scope.searchResult = cityService.searchResult;
}]);

eShopApp.controller('devLinksController', ['$scope', '$resource', 'cityService', function ($scope, $resource, cityService) {
    $scope.searchResult = cityService.searchResult;
}]);