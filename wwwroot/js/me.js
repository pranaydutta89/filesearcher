(function (window) {
    window.angularApp.controller('meController', ['$http', '$q', function ($http, $q) {

        this.startScanning = function () {
            $http.get('/home/scan');
        }

    }]);
})(window)