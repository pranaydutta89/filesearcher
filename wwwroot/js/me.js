(function (window) {
    window.angularApp.controller('meController', ['$http', '$q','fileTypes', function ($http, $q,fileTypes) {
        this.files = [];
        var _this = this;
        this.page = 1
        $http.get("/home/files?page=" + this.page).then(function (res) {
            _this.files.push.apply(_this.files, res.data);
        })

        this.startScanning = function () {
            $http.get('/home/scan');
        }

    }]);
})(window)