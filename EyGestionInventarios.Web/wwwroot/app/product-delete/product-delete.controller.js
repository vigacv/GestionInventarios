(function () {
    'use strict';

    angular
        .module('app')
        .controller('productDelete', ['apiService', '$scope', '$location', productDelete]);

    productDelete.$inject = ['$location'];

    function productDelete(apiService, $scope, $location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'productDelete';
        $scope.producto = {};

        $scope.borrarProducto = function () {
            if ($scope.producto.codArt) {
                apiService.delete($scope.producto.codArt).then(function success(promise) {
                    console.log(promise);
                    $location.path('/#!')
                });
            } else {
                alert("Debe llenar el campo 'Codigo'")
            }
            
        };

        activate();

        function activate() { }
    }
})();
