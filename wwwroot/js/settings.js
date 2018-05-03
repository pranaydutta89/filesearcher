(function (window) {

    window.angularApp.controller('startController', ['$http', function ($http) {
        var _this = this;
        $http.get('/settings/folderList').then(function (res) {
            _this.folders = res.data;
        });

        this.addFolder = function () {
            _this.folders.push({folderPath:_this.folderPath});
            _this.folderPath = "";
        }

        this.updateFolderList = function () {
            $http.put('/settings/folderList', _this.folders);
        }
    }]);

})(window)