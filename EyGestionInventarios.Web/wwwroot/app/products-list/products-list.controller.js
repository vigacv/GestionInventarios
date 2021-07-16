(function () {
    'use strict';

    angular
        .module('app')
        .controller('productsList', ['apiService', '$scope', productsList]);

    productsList.$inject = ['$location'];

    function productsList(apiService, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'productsList';
        $scope.home = "Test";

        //this.articulos = apiService.getData();

        activate();

        function activate() {
            apiService.getData().then(function success(promise) {
                $scope.listaArticulos = promise;
            });
        }
    }
})();