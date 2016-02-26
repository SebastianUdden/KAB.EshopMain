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

    .when('/shopping-cart', {
        templateUrl: 'pages/shoppingCart.html',
        controller: 'shoppingCartController'
    })

    .when('/user-log-in', {
        templateUrl: 'pages/userLogin.html',
        controller: 'userLoginController'
    })

    .when('/user-sign-up', {
        templateUrl: 'pages/userRegister.html',
        controller: 'userRegisterController'
    })
});

eShopApp.service('shopService', function() {
    this.searchResult = "";
});

eShopApp.controller('headerController', ['$scope', 'shopService', function ($scope, shopService) {
    $scope.searchResult = shopService.searchResult;

    $scope.$watch('searchResult', function () {
        shopService.searchResult = $scope.searchResult;
    });
}]);


eShopApp.controller('homeController', ['$scope', 'shopService', function($scope, shopService) {
}]);

//eShopApp.controller('adminController', ['$scope', function($scope) {
//}]);

eShopApp.controller('searchQueryController', ['$scope', '$resource', 'shopService', function($scope, $resource, shopService) {
    $scope.searchResult = shopService.searchResult;
}]);

eShopApp.controller('devLinksController', ['$scope', '$resource', 'shopService', function ($scope, $resource, shopService) {
}]);

eShopApp.controller('shoppingCartController', ['$scope', '$resource', 'shopService', function ($scope, $resource, shopService) {
}]);

eShopApp.controller('userRegisterController', ['$scope', '$resource', 'shopService', function ($scope, $resource, shopService) {
}]);