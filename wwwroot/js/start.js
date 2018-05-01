(function (window) {

    window.angularApp.controller('startController', ['$http', function ($http) {
        var _this = this;
        $http.get('/start/fileList').then(function (res) {
            _this.folders = res.data;
        });

        this.addFolder = function () {
            _this.folders.push(_this.folderPath);
            _this.folderPath = "";
        }

        this.updateFolderList = function () {
            $http.put('/start/fileList', _this.folders);
        }
    }]);

})(window)