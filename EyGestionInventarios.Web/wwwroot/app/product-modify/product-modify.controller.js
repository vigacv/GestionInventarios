(function () {
    'use strict';

    angular
        .module('app')
        .controller('productModify', ['apiService', '$scope', '$location', productModify]);

    productModify.$inject = ['$location'];

    function productModify(apiService, $scope, $location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'productModify';
        $scope.producto = {};

        $scope.modificarProducto = function () {
            if ($scope.producto.codArt) {
                apiService.update($scope.producto).then(function success(promise) {
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
