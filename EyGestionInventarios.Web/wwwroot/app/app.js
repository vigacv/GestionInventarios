(function () {
    'use strict';

    var app = angular.module('app', [
        // Angular modules
        'ngRoute'
        // Custom modules 
        
        // 3rd Party Modules

    ]);

    app.config(['$routeProvider',
        function config($routeProvider) {
            $routeProvider.
                when('/', {
                    controller: 'productsList',
                    templateUrl: 'app/products-list/products.html'
                }).when('/modify', {
                    controller: 'productModify',
                    templateUrl: 'app/product-modify/modify.html'
                }).when('/delete', {
                    controller: 'productDelete',
                    templateUrl: 'app/product-delete/delete.html'
                }).when('/insert', {
                    controller: 'productInsert',
                    templateUrl: 'app/product-insert/insert.html'
                }).otherwise('/')
        }
    ]);

})();