(function (window) {

    window.angularApp.controller('startController', ['$http', function ($http) {

        $http.get('/start/fileList').then(function (res) {
            this
        })
    }])

})(window)