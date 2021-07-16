
(function () {
    'use strict';

    angular
        .module('app')
        .controller('productInsert', ['apiService', '$scope', '$location', productInsert]);

    productInsert.$inject = ['$location'];

    function productInsert(apiService, $scope, $location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'productInsert';
        $scope.producto = {};

        $scope.insertarProducto = function () {
            if ($scope.producto.codArt) {
                apiService.insert($scope.producto).then(function success(promise) {
                    console.log(promise);
                    $location.path('/#!')
                });
            } else {
                alert("Debe llenar el campo 'Codigo'")
            }
            
        };

        activate();

        function activate() {
        }
    }
})();
