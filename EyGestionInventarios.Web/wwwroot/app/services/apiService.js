(function () {
    'use strict';

    angular
        .module('app')
        .factory('apiService', ['$q','$http', apiService]);

    function apiService($q, $http) {

        var serviceBase = "http://localhost:16993/";

        var service = {
            getData: getData,
            insert: insert,
            delete: deleteProd,
            update: update
        }

        return service;

        function getData() {
            var deferred = $q.defer();
            $http({ url: serviceBase + "producto", method: "GET" })
                .then(function success(response) {
                    console.log("Consulta HTTP exitosa: " + response.status);
                    deferred.resolve(response.data);
            }, function error(data) {
                    console.log("Error al hacer la consulta HTTP: ", data);
                    deferred.reject();
            });
            return deferred.promise;
        }

        function insert(prod) {
            var prodJson = JSON.stringify(prod);
            console.log("Enviando datos " + prodJson);
            var deferred = $q.defer();
            $http.post(serviceBase + "producto", prodJson)
                .then(function success(response) {
                    console.log("POST HTTP exitoso: " + response.status);
                    deferred.resolve(response.data);
                }, function error(data) {
                    console.log("Error al hacer el POST HTTP: ", data);
                    deferred.reject();
                });
            return deferred.promise;
        }

        function deleteProd(cod){
            var deferred = $q.defer();
            $http.delete(serviceBase + "producto/"+cod)
                .then(function success(response) {
                    console.log("DELETE HTTP exitoso: " + response.status);
                    deferred.resolve(response.data);
                }, function error(data) {
                    console.log("Error al hacer el DELETE HTTP: ", data);
                    deferred.reject();
                });
            return deferred.promise;
        }

        function update(prod) {
            var prodJson = JSON.stringify(prod);            
            var deferred = $q.defer();
            $http.put(serviceBase + "producto/" + prod.codArt, prodJson)
                .then(function success(response) {
                    console.log("PUT HTTP exitoso: " + response.status);
                    deferred.resolve(response.data);
                }, function error(data) {
                    console.log("Error al hacer el PUT HTTP: ", data);
                    deferred.reject();
                });
            return deferred.promise;
        }
    }
})();